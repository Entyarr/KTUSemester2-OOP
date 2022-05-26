using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Methods
{
    public class TaskUtils
    {
        /// <summary>
        /// Gets all items that match the order
        /// </summary>
        /// <param name="warehouses">Warehouses</param>
        /// <param name="order">Order</param>
        /// <returns>List of wares that match order</returns>
        public static List<Wares> GetOrderItems(List<Warehouse> warehouses, List<Wares> order)
        {
            return warehouses.SelectMany(x => x.Items)
                             .Where(y => order.Any(z => z.Item == y.Item))
                             .OrderBy(x => x.Price).ToList();
        }
        /// <summary>
        /// Finds all items under and over the asking price
        /// </summary>
        /// <param name="wares">List of wares</param>
        /// <param name="order">Order</param>
        /// <returns>Tuple of wares lists that are under and over the price, respectivelly</returns>
        public static List<Wares> UnderAskPrice(List<Wares> wares, List<Wares> order)
        {
            return wares.Where(x => order.Any(y => y.Item == x.Item && y.Price > x.Price))
                        .OrderBy(x => x.Price).ToList();
        }
        /// <summary>
        /// Finds which items are out of stock
        /// </summary>
        /// <param name="wares"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static List<Wares> OutOfStock(List<Wares> wares, List<Wares> order)
        {
            List<Wares> stock = new List<Wares>();
            foreach(var o in order)
            {
                int amount = wares.Where(x => x.Item == o.Item).Sum(x => x.Amount);
                if(o.Amount > amount)
                {
                    Wares ware = new Wares(o.Item, o.Amount - amount, 0);
                    ware.info = "Nera sandėlyje";
                    stock.Add(ware);
                }
            }
            return stock;
        }
        /// <summary>
        /// Matches the order amount to asking amount
        /// </summary>
        /// <param name="wares">List of wares</param>
        /// <param name="amount">Amount wanted</param>
        /// <returns>Tuple of matched wares and those that didnt fit</returns>
        public static Tuple<List<Wares>,List<Wares>> MatchAskingAmount(List<Wares> wares, List<Wares> order)
        {
            List<Wares> lost = new List<Wares>();

            //Continues loop while total amount is above asking amount
            foreach (var o in order)
            {
                int totalAmount = wares.Where(x => x.Item == o.Item).Sum(y => y.Amount);
                foreach (var w in wares)
                {
                    if (o.Item == w.Item)
                    {
                        string itemLost = w.Item;
                        int amountLost = 0;
                        decimal priceLost = w.Price;

                        while (w.Amount > 0 && totalAmount > o.Amount)
                        {
                            w.Amount--;
                            totalAmount--;

                            amountLost++;
                        }
                        if (amountLost > 0)
                        {
                            Wares ware = new Wares(itemLost, amountLost, priceLost);
                            ware.info = "Netilpo į užsakymą";
                            lost.Add(ware);
                        }
                    }
                }
            }
         

            List<Wares> finalWares = wares.Where(x => x.Amount > 0)
                                          .OrderByDescending(x => x.Price).ToList();

            return Tuple.Create(finalWares, lost);
        }
        /// <summary>
        /// Applies store limitation to order
        /// </summary>
        /// <param name="wares">List of wares</param>
        /// <param name="limitation">Limitation to adhere to</param>
        /// <returns>Tuple of items that fit within limitation and didn't</returns>
        public static Tuple<List<Wares>,List<Wares>> ApplyLimitation(List<Wares> wares, decimal limitation)
        {
            decimal payingPrice = wares.Sum(x => x.Amount * x.Price);
            List<Wares> lost = new List<Wares>();

            foreach(var w in wares)
            {
                string itemLost = w.Item;
                int amountLost = 0;
                decimal priceLost = w.Price;
                
                while(payingPrice > limitation && w.Amount > 0)
                {
                    w.Amount--;
                    payingPrice -= w.Price;

                    amountLost++;
                }
                if (amountLost > 0)
                {
                    Wares ware = new Wares(itemLost, amountLost, priceLost);
                    ware.info = "Per brangu";
                    lost.Add(ware);
                }
            }
            List<Wares> limitedWares = wares.Where(x => x.Amount > 0)
                                            .OrderByDescending(x => x.Price).ToList();

            return Tuple.Create(limitedWares, lost);
        }
        /// <summary>
        /// Combines three lists and sorts them
        /// </summary>
        /// <param name="list1">First list</param>
        /// <param name="list2">Second list</param>
        /// <param name="list3">Third list</param>
        /// <returns>Combined list</returns>
        public static List<Wares> Combine3Lists(List<Wares> list1, List<Wares> list2, List<Wares> list3)
        {
            return list1.Union(list2.Union(list3)).OrderBy(x => x.Item).ThenByDescending(x => x.Price).ToList();
        }
    }
}