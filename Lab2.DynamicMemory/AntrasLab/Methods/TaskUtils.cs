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
        public static CustomersByAgentList Reformat(AgentList agents, CustomerList customers)
        {
            CustomersByAgentList AgentMasterList = new CustomersByAgentList();
            
            foreach(Agent a in agents)
            {
                CustomerList onlyAgent = new CustomerList();
                string agentName = a.AgentName();
                string agentCode = a.AgentCode;
                foreach(Customer c in customers)
                {
                    if (c.AgentCode == agentCode) onlyAgent.AddToEnd(c);
                }
                AgentMasterList.AddToEnd(new CustomersByAgent(agentName, agentCode, onlyAgent));
            }
            return AgentMasterList;
            
        }
        /// <summary>
        /// Gives a list of customers that order in a given month
        /// </summary>
        /// <param name="agents">List of agents</param>
        /// <param name="month">Given month</param>
        public static void CustomersInGivenMonth(CustomersByAgentList agents, int month)
        {
            foreach(CustomersByAgent a in agents)
            {
                CustomerList filteredCustomers = new CustomerList();
                foreach(Customer c in a.Customers)
                {
                    int endMonth = c.SubStart + c.SubEnd;
                    if(c.SubStart <= month && month < endMonth)
                    {
                        filteredCustomers.AddToEnd(c);
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
        public static int MagazineAmount(CustomersByAgentList agents)
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
        public static void AgentMagazineAmount(CustomersByAgentList agents)
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
        public static CustomersByAgentList AboveAverage(CustomersByAgentList agents, int allMagCounts)
        {
            CustomersByAgentList filtered = new CustomersByAgentList();

            foreach(CustomersByAgent a in agents)
            {
                if (a.AllMagCount > allMagCounts / (double)HowManyHaveCustomers(agents))
                {
                    filtered.AddToEnd(a);
                }
            }

            return filtered;
        }
        /// <summary>
        /// Calculates how many agents have atleast one agent
        /// </summary>
        /// <param name="agents">Agent list</param>
        /// <returns>Sum of atleast one customer</returns>
        public static int HowManyHaveCustomers(CustomersByAgentList agents)
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
        public static CustomersByAgentList ReplaceCustomers(CustomersByAgentList agents, CustomersByAgentList aboveAvgAgents, int monthlyMagCount)
        {
            CustomersByAgentList newList = new CustomersByAgentList();
            double average = monthlyMagCount / (double)HowManyHaveCustomers(agents);
            agents.Sort();

            foreach(CustomersByAgent a in agents)
            {
                if(a.AllMagCount < average)
                {
                    foreach(Customer c in a.Customers)
                    {
                        GetMinimumMagAgent(aboveAvgAgents).WasExpanded = true;
                        GetMinimumMagAgent(aboveAvgAgents).Customers.AddToEnd(c);
                    }
                }
            }

            foreach(CustomersByAgent a in aboveAvgAgents)
            {
                if(a.WasExpanded)
                {
                    newList.AddToEnd(a);
                }
            }    

            return newList;
        }
        /// <summary>
        /// Gets the agent with the least magazines sold
        /// </summary>
        /// <param name="agents"></param>
        /// <returns></returns>
        public static CustomersByAgent GetMinimumMagAgent(CustomersByAgentList agents)
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