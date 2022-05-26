using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Creates agent
    /// </summary>
    public class Agent: IEquatable<Agent>, IComparable<Agent>
    {
        public string AgentCode { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }

        public Agent(string code, string lastName, string name, string address, string number)
        {
            AgentCode = code;
            LastName = lastName;
            Name = name;
            Address = address;
            Number = number;
        }
        /// <summary>
        /// Gets full name of agent
        /// </summary>
        /// <returns>Agent name</returns>
        public string AgentName()
        {
            return String.Format("{0} {1}", Name, LastName);
        }
        /// <summary>
        /// Checks if agent is equal to other agent
        /// </summary>
        /// <param name="other">other agent</param>
        /// <returns>True or false</returns>
        public bool Equals(Agent other)
        {
            return AgentCode == other.AgentCode &&
                  LastName == other.LastName &&
                  Name == other.Name &&
                  Address == other.Address &&
                  Number == other.Number;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares agent name to another agent
        /// </summary>
        /// <param name="other">Other agent</param>
        /// <returns>1 or -1 (true or false)</returns>
        public int CompareTo(Agent other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return String.Format("| {0,-12} | {1,-15} | {2,-8} | {3,-15} | {4,-10} |",
                                 AgentCode, LastName, Name, Address, Number);
        }
    }
}