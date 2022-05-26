using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Creates a list of customers using nodes
    /// </summary>
    public class CustomerList : IEnumerable<Customer>
    {
        private CustomerNode head;
        private CustomerNode tail;

        /// <summary>
        /// Adds to the ned of the list
        /// </summary>
        /// <param name="customer">A single customer</param>
        public void AddToEnd(Customer customer)
        {
            CustomerNode node = new CustomerNode(customer);
            if (tail != null && head != null)
            {
                tail.Next = node;
                tail = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }
        /// <summary>
        /// Adds to the start of the list
        /// </summary>
        /// <param name="customer">A single customer</param>
        public void AddToStart(Customer customer)
        {
            CustomerNode node = new CustomerNode(customer);
            if (tail != null && head != null)
            {
                node.Next = head;
                head = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }
        /// <summary>
        /// Gets customer at given index
        /// </summary>
        /// <param name="index">Index of wanted customer</param>
        /// <returns>Wanted customer</returns>
        public Customer Get(int index)
        {
            int i = 0;
            CustomerNode current = head;
            while (i < index && current != null)
            {
                current = head.Next;
                i++;
            }
            return current.Data;
        }
        /// <summary>
        /// Gets the count of customers in the list
        /// </summary>
        /// <returns>Count of customers</returns>
        public int Count()
        {
            int count = 0;
            CustomerNode current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Sorts the list
        /// </summary>
        public void Sort()
        {
            for (CustomerNode nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                CustomerNode min = nodeA;
                for (CustomerNode nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data < min.Data)
                    {
                        min = nodeB;
                    }
                }

                Customer tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }
        /// <summary>
        /// Enumerates the customers, to be used in foreach loops
        /// </summary>
        /// <returns>Data</returns>
        public IEnumerator<Customer> GetEnumerator()
        {
            CustomerNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// Required to enumerate
        /// </summary>
        /// <returns>Data</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}