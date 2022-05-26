using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines a list of agents with their specific customers
    /// </summary>
    public class CustomersByAgent
    {
        public string Agent { get; set; }
        public string AgentCode { get; set; }
        public CustomerList Customers { get; set; }
        public int AllMagCount { get; set; }
        public bool WasExpanded { get; set; }
        public CustomersByAgent(string agent, string agentCode, CustomerList customers, int allMagCount = 0, bool wasExpanded = false)
        {
            Agent = agent;
            AgentCode = agentCode;
            Customers = customers;
            AllMagCount = allMagCount;
            WasExpanded = wasExpanded;
        }
        /// <summary>
        /// Compares two agents
        /// </summary>
        /// <param name="a">First agent</param>
        /// <param name="b">Second agent</param>
        /// <returns>Whether the comparison is true or false</returns>
        public static bool operator <(CustomersByAgent a, CustomersByAgent b)
        {
            if (a.AllMagCount.CompareTo(b.AllMagCount) < 0)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Compares two agents
        /// </summary>
        /// <param name="a">First agent</param>
        /// <param name="b">Second agent</param>
        /// <returns>Whether the comparison is true or false</returns>
        public static bool operator >(CustomersByAgent a, CustomersByAgent b)
        {
            if (a.AllMagCount.CompareTo(b.AllMagCount) > 0)
            {
                return true;
            }

            return false;
        }
    }
}