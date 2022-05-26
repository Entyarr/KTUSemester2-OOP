using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Creates a list of agents with their customer list using nodes
    /// </summary>
    public class CustomersByAgentList : IEnumerable<CustomersByAgent>
    {
        private CustomersByAgentNode head;
        private CustomersByAgentNode tail;
        /// <summary>
        /// Adds to the end of the list
        /// </summary>
        /// <param name="agent">A single agent</param>
        public void AddToEnd(CustomersByAgent agent)
        {
            CustomersByAgentNode node = new CustomersByAgentNode(agent);
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
        /// <param name="agent">A single agent</param>
        public void AddToStart(CustomersByAgent agent)
        {
            CustomersByAgentNode node = new CustomersByAgentNode(agent);
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
        /// Gets an agent from a given index
        /// </summary>
        /// <param name="index">Wanted index of an agent</param>
        /// <returns>Wanted agent</returns>
        public CustomersByAgent Get(int index)
        {
            int i = 0;
            CustomersByAgentNode current = head;
            while (i < index && current != null)
            {
                current = head.Next;
                i++;
            }
            return current.Data;
        }
        /// <summary>
        /// Count of all agents in the list
        /// </summary>
        /// <returns>Count of agents</returns>
        public int Count()
        {
            int count = 0;
            CustomersByAgentNode current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Sorts the agents
        /// </summary>
        public void Sort()
        {
            for (CustomersByAgentNode nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                CustomersByAgentNode min = nodeA;
                for (CustomersByAgentNode nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data < min.Data)
                    {
                        min = nodeB;
                    }
                }

                CustomersByAgent tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }
        /// <summary>
        /// Enumerated the agents, so it could be used in foreach loops
        /// </summary>
        /// <returns>Data</returns>
        public IEnumerator<CustomersByAgent> GetEnumerator()
        {
            CustomersByAgentNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// Needed to enumerate
        /// </summary>
        /// <returns>Data</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}