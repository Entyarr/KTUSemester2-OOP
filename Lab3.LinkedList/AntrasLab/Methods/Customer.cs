using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines a customer
    /// </summary>
    public class Customer: IEquatable<Customer>, IComparable<Customer>
    {
        public string Address { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public int SubStart { get; set; }
        public int SubEnd { get; set; }
        public string SubCode { get; set; }
        public int MagAmount { get; set; }
        public string AgentCode { get; set; }

        public Customer(string address, string name, string number, int start, int end, string code, int magCount, string agent)
        {
            Address = address;
            LastName = name;
            Number = number;
            SubStart = start;
            SubEnd = end;
            SubCode = code;
            MagAmount = magCount;
            AgentCode = agent;
        }
        /// <summary>
        /// Checks if two customers are the same
        /// </summary>
        /// <param name="other">Other comparable customer</param>
        /// <returns>True/False if its the same thing</returns>
        public bool Equals(Customer other)
        {
            return Address == other.Address &&
                   LastName == other.LastName &&
                   Number == other.Number &&
                   SubStart == other.SubStart &&
                   SubEnd == other.SubEnd &&
                   SubCode == other.SubCode &&
                   MagAmount == other.MagAmount &&
                   AgentCode == other.AgentCode;
        }
        /// <summary>
        /// Compares two customers
        /// </summary>
        /// <param name="other">Other customer</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(Customer other)
        {
            if (AgentCode.CompareTo(other.AgentCode) > 0)
            {
                return 1;
            }
            else if (AgentCode.CompareTo(other.AgentCode) == 0 && Address.CompareTo(other.Address) > 0)
            {
                return 1;
            }
            else if (AgentCode.CompareTo(other.AgentCode) == 0 && Address.CompareTo(other.Address) == 0 &&
                     LastName.CompareTo(other.LastName) > 0)
            {
                return 1;
            }

            return -1;
        }
        public override string ToString()
        {
            return String.Format("| {0,-15} | {1,-15} | {2,-10} | {3,7} | {4,6} | {5,-8} | {6,6} | {7,-12} |",
                                 Address, LastName, Number, SubStart, SubEnd, SubCode, MagAmount, AgentCode);
        }
    }
}