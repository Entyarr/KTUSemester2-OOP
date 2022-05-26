using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// All classes that do stuff
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Reformats agents and customers linked lists into one massive list with their respective customers
        /// </summary>
        /// <param name="agents">Agent list</param>
        /// <param name="customers">Customer list</param>
        /// <returns>Agent list with their respective customers</returns>
        public static LinkedList<CustomersByAgent> Reformat(LinkedList<Agent> agents, LinkedList<Customer> customers)
        {
            LinkedList<CustomersByAgent> AgentMasterList = new LinkedList<CustomersByAgent>();
            
            foreach(Agent a in agents)
            {
                LinkedList<Customer> onlyAgent = new LinkedList<Customer>();
                string agentName = a.AgentName();
                string agentCode = a.AgentCode;
                foreach(Customer c in customers)
                {
                    if (c.AgentCode == agentCode) onlyAgent.Add(c);
                }
                AgentMasterList.Add(new CustomersByAgent(agentName, agentCode, onlyAgent));
            }
            return AgentMasterList;
            
        }
        /// <summary>
        /// Gives a list of customers that order in a given month
        /// </summary>
        /// <param name="agents">List of agents</param>
        /// <param name="month">Given month</param>
        public static void CustomersInGivenMonth(LinkedList<CustomersByAgent> agents, int month)
        {
            foreach(CustomersByAgent a in agents)
            {
                LinkedList<Customer> filteredCustomers = new LinkedList<Customer>();
                foreach(Customer c in a.Customers)
                {
                    int endMonth = c.SubStart + c.SubEnd;
                    if(c.SubStart <= month && month < endMonth)
                    {
                        filteredCustomers.Add(c);
                    }
                }
                a.Customers = filteredCustomers;
            }
        }
        /// <summary>
        /// Calculates how many magazines were sold by the agents
        /// </summary>
        /// <param name="agents">Agent list</param>
        /// <returns>Sum of magazines</returns>
        public static int MagazineAmount(LinkedList<CustomersByAgent> agents)
        {
            int sum = 0;
            foreach(CustomersByAgent a in agents)
            {
                foreach (Customer c in a.Customers) sum += c.MagAmount;
            }
            return sum;
        }
        /// <summary>
        /// Calculates how many magazines were sold by the agents and is applied to them
        /// </summary>
        /// <param name="agents">List of agents</param>
        public static void AgentMagazineAmount(LinkedList<CustomersByAgent> agents)
        {
            foreach (CustomersByAgent a in agents)
            {
                int sum = 0;
                foreach (Customer c in a.Customers) sum += c.MagAmount;
                a.AllMagCount = sum;
            }
        }
        /// <summary>
        /// Finds which agents have sold more magazines than the average count
        /// </summary>
        /// <param name="agents">List of agents</param>
        /// <param name="allMagCounts">All magazines sold</param>
        /// <returns>All agents above average</returns>
        public static LinkedList<CustomersByAgent> AboveAverage(LinkedList<CustomersByAgent> agents, int allMagCounts)
        {
            LinkedList<CustomersByAgent> filtered = new LinkedList<CustomersByAgent>();

            foreach(CustomersByAgent a in agents)
            {
                if (a.AllMagCount > allMagCounts / (double)HowManyHaveCustomers(agents))
                {
                    filtered.Add(a);
                }
            }

            return filtered;
        }
        /// <summary>
        /// Calculates how many agents have atleast one agent
        /// </summary>
        /// <param name="agents">Agent list</param>
        /// <returns>Sum of atleast one customer</returns>
        public static int HowManyHaveCustomers(LinkedList<CustomersByAgent> agents)
        {
            int sum = 0;
            foreach(CustomersByAgent a in agents)
            {
                if (a.Customers.Count() > 0) sum++;
            }
            return sum;
        }
        /// <summary>
        /// Gives all the above average agents the customers of below average agents
        /// </summary>
        /// <param name="agents">List of agents</param>
        /// <param name="aboveAvgAgents">List of above average agents</param>
        /// <param name="monthlyMagCount">All magazines sold in specific month</param>
        /// <returns>List of agents with new customers</returns>
        public static LinkedList<CustomersByAgent> ReplaceCustomers(LinkedList<CustomersByAgent> agents, LinkedList<CustomersByAgent> aboveAvgAgents, int monthlyMagCount)
        {
            LinkedList<CustomersByAgent> newList = new LinkedList<CustomersByAgent>();
            double average = monthlyMagCount / (double)HowManyHaveCustomers(agents);
            agents.Sort();

            ///Assigns the below average agent customers to above average agents
            foreach(CustomersByAgent a in agents)
            {
                if(a.AllMagCount < average)
                {
                    foreach(Customer c in a.Customers)
                    {
                        GetMinimumMagAgent(aboveAvgAgents).WasExpanded = true;
                        GetMinimumMagAgent(aboveAvgAgents).Customers.Add(c);
                    }
                }
            }

            ///Adds all agents who received new customers to a list     
            foreach(CustomersByAgent a in aboveAvgAgents)
            {
                if(a.WasExpanded)
                {
                    newList.Add(a);
                }
            }    

            return newList;
        }
        /// <summary>
        /// Sorts customers for each agent in a master list
        /// </summary>
        /// <param name="list"></param>
        public static void SortMasterList(LinkedList<CustomersByAgent> list)
        {
            foreach(CustomersByAgent a in list )
            {
                a.Customers.Sort();
            }
        }
        /// <summary>
        /// Gets the agent with the least magazines sold
        /// </summary>
        /// <param name="agents"></param>
        /// <returns></returns>
        public static CustomersByAgent GetMinimumMagAgent(LinkedList<CustomersByAgent> agents)
        {
            CustomersByAgent lowest = agents.Get(0);
            foreach (CustomersByAgent a in agents)
            {
                if(a.AllMagCount < lowest.AllMagCount)
                {
                    lowest = a;
                }    
            }
            return lowest;
        }
    }
}