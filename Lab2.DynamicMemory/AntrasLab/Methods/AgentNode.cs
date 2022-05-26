using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines a single node
    /// </summary>
    public class AgentNode
    {
        public Agent Data { get; set; }
        public AgentNode Next { get; set; }
        public AgentNode() { }
        public AgentNode(Agent data = null, AgentNode next = null)
        {
            Data = data;
            Next = next;
        }
    }
}