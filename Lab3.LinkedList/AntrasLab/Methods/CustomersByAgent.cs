using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines a list of agents with their specific customers
    /// </summary>
    public class CustomersByAgent: IEquatable<CustomersByAgent>, IComparable<CustomersByAgent>
    {
        public string Agent { get; set; }
        public string AgentCode { get; set; }
        public LinkedList<Customer> Customers { get; set; }
        public int AllMagCount { get; set; }
        public bool WasExpanded { get; set; }
        public CustomersByAgent(string agent, string agentCode, LinkedList<Customer> customers, int allMagCount = 0, bool wasExpanded = false)
        {
            Agent = agent;
            AgentCode = agentCode;
            Customers = customers;
            AllMagCount = allMagCount;
            WasExpanded = wasExpanded;
        }
        /// <summary>
        /// Checks if agent is equal to another
        /// </summary>
        /// <param name="other">Other agent</param>
        /// <returns>True or false</returns>
        public bool Equals(CustomersByAgent other)
        {
            return Agent == other.Agent &&
                   AgentCode == other.AgentCode &&
                   Customers == other.Customers &&
                   AllMagCount == other.AllMagCount;
        }
        /// <summary>
        /// Compares two agents by total magazine count
        /// </summary>
        /// <param name="other">Other agent</param>
        /// <returns>1 or -1 (true or false)</returns>
        public int CompareTo(CustomersByAgent other)
        {
            if (AllMagCount.CompareTo(other.AllMagCount) < 0)
            {
                return -1;
            }
            return 1;
        }
    }
}