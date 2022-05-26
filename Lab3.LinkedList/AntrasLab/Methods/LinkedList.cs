using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Generic linked list class. Used for storing a list of values.
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    public class LinkedList<T> : IEnumerable<T>, IComparable<LinkedList<T>> where T : IComparable<T>
    {
        /// <summary>
        /// Defines a node
        /// </summary>
        class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next = null)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;
        private Node tail;

        /// <summary>
        /// Creates an empty linked list
        /// </summary>
        public LinkedList()
        {
        }
        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// Add a single element to the linked list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            Node node = new Node(item);
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
        /// Gets item from list at wanted index
        /// </summary>
        /// <param name="index">Index of the item</param>
        /// <returns>Item</returns>
        public T Get(int index)
        {
            int i = 0;
            Node current = head;
            while (i < index && current.Next != null)
            {
                current = current.Next;
                i++;
            }
            return current.Data;
        }

        /// <summary>
        /// Count how many elemnts are stored in this list
        /// </summary>
        /// <returns>Number of stored elements</returns>
        public int Count()
        {
            int count = 0;
            for (Node d = head; d != null; d = d.Next)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Sorts the linked list
        /// </summary>
        public void Sort()
        {
            for (Node nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                Node min = nodeA;
                for (Node nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data.CompareTo(min.Data) < 0)
                    {
                        min = nodeB;
                    }
                }

                T tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }

        /// <summary>
        /// Enumerates the list
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (Node d = head; d != null; d = d.Next)
                yield return d.Data;
        }

        /// <summary>
        /// Enumerate the list
        /// </summary>
        /// <returns>An enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Included compareto method, so compareto could be used in this file
        /// </summary>
        /// <param name="other">Other linked list</param>
        /// <returns>Method doesn't return</returns>
        public int CompareTo(LinkedList<T> other)
        {
            throw new NotImplementedException();
        }
    }
}