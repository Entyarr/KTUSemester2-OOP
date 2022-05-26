using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// A list of agents made of nodes
    /// </summary>
    public class AgentList : IEnumerable<Agent>
    {
        private AgentNode head;
        private AgentNode tail;
        /// <summary>
        /// Adds to the end of the list
        /// </summary>
        /// <param name="agent">A single agent</param>
        public void AddToEnd(Agent agent)
        {
            AgentNode node = new AgentNode(agent);
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
        public void AddToStart(Agent agent)
        {
            AgentNode node = new AgentNode(agent);
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
        /// Gets agent from list at given index
        /// </summary>
        /// <param name="index">Which index agent we want</param>
        /// <returns>Wanted agent</returns>
        public Agent Get(int index)
        {
            int i = 0;
            AgentNode current = head;
            while (i < index && current != null)
            {
                current = head.Next;
                i++;
            }
            return current.Data;
        }
        /// <summary>
        /// Counts how many agents there are in a list
        /// </summary>
        /// <returns>Amount of agents in list</returns>
        public int Count()
        {
            int count = 0;
            AgentNode current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Enumerates agents, so it could be used in foreach loops
        /// </summary>
        /// <returns>Data</returns>
        public IEnumerator<Agent> GetEnumerator()
        {
            AgentNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// Required to enumerate the list
        /// </summary>
        /// <returns>Data</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}