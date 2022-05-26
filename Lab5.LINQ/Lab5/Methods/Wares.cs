using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Methods
{
    /// <summary>
    /// Creates item to sell
    /// </summary>
    public class Wares
    {
        public string Item { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string info { get; set; }
        public Wares (string item, int amount, decimal price)
        {
            Item = item;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return String.Format("| {0,-20} | {1,8} | {2,8} |", Item, Amount, Price);
        }
    }
}