using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Creates agent
    /// </summary>
    public class Agent
    {
        public string AgentCode { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public int AllMagCounts { get; set; }

        public Agent(string code, string lastName, string name, string address, string number, int allMags = 0)
        {
            AgentCode = code;
            LastName = lastName;
            Name = name;
            Address = address;
            Number = number;
            AllMagCounts = allMags;
        }
        /// <summary>
        /// Gets full name of agent
        /// </summary>
        /// <returns>Agent name</returns>
        public string AgentName()
        {
            return String.Format("{0} {1}", Name, LastName);
        }

    }
}