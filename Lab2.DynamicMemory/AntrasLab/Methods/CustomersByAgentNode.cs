using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Defines agent node
    /// </summary>
    public class CustomersByAgentNode
    {
        public CustomersByAgent Data { get; set; }
        public CustomersByAgentNode Next { get; set; }
        public CustomersByAgentNode(CustomersByAgent data = null, CustomersByAgentNode next = null)
        {
            Data = data;
            Next = next;
        }
    }
}