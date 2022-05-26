using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines a customer
    /// </summary>
    public class Customer
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
        /// Compares two customers
        /// </summary>
        /// <param name="a">First customer</param>
        /// <param name="b">Second customer</param>
        /// <returns>Whether the comparison is true or false</returns>
        public static bool operator <(Customer a, Customer b)
        {
            if (a.AgentCode.CompareTo(b.AgentCode) < 0)
            {
                return true;
            }
            else if (a.AgentCode.CompareTo(b.AgentCode) == 0 && a.Address.CompareTo(b.Address) < 0)
            {
                return true;
            }
            else if (a.AgentCode.CompareTo(b.AgentCode) == 0 && a.Address.CompareTo(b.Address) == 0 && a.LastName.CompareTo(b.LastName) < 0)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Compares two customers
        /// </summary>
        /// <param name="a">First customer</param>
        /// <param name="b">Second customer</param>
        /// <returns>Whether the comparison is true or false</returns>
        public static bool operator >(Customer a, Customer b)
        {
            if (a.AgentCode.CompareTo(b.AgentCode) > 0)
            {
                return true;
            }
            else if (a.AgentCode.CompareTo(b.AgentCode) == 0 && a.Address.CompareTo(b.Address) > 0)
            {
                return true;
            }
            else if (a.AgentCode.CompareTo(b.AgentCode) == 0 && a.Address.CompareTo(b.Address) == 0)
            {
                return a.LastName.CompareTo(b.LastName) > 0;
            }

            return false;
        }
    }
}