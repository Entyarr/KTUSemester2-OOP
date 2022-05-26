using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Methods
{
    /// <summary>
    /// Creates warehouse
    /// </summary>
    public class Warehouse
    {
        public int Number { get; set; }
        public List<Wares> Items { get; set; }
        public Warehouse(int number, List<Wares> items)
        {
            Number = number;
            Items = items;
        }
    }
}