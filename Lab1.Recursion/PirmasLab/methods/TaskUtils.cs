using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PirmasLab.methods
{
    /// <summary>
    /// Methods used to find most optimal route and its price
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Recursive method, that tests every single possible route combination
        /// </summary>
        /// <param name="courier"></param>
        /// <param name="start">Where to start swapping destinations (ensures that 1st point always stays first)</param>
        /// <param name="end">Where to end swapping destinations (ensures that last point always stays last)</param>
        /// <param name="routes">Returns the most optimal route to take for the courier</param>
        /// <param name="cheapest">Returns the cheapest price that can be found</param>
        public static void Task(Courier courier, int start, int end, ref List<int> routes, ref int cheapest)
        {
            if (start == end)
            {
                int sum = Price(courier.Route, courier.Prices);
                if (sum <= cheapest)
                {
                    routes.Clear();
                    cheapest = sum;
                    for(int m = 0; m < courier.Route.Length; m++)
                    {
                        routes.Add(courier.Route[m]);
                    }
                }
                
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    swap(ref courier.Route[start], ref courier.Route[i]);
                    Task(courier, start + 1, end, ref routes, ref cheapest);
                    swap(ref courier.Route[start], ref courier.Route[i]);
                }
            }
        }

        /// <summary>
        /// Swaps two integers
        /// </summary>
        /// <param name="x">First integer</param>
        /// <param name="y">Second integer</param>
        private static void swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Calculates the price of a route
        /// </summary>
        /// <param name="route">Route that will be taken</param>
        /// <param name="prices">Price map from each route to another</param>
        /// <returns>Price of the route</returns>
        private static int Price(int[] route, int[,] prices)
        {
            int sum = 0;
            for (int i = 0; i < route.Length - 1; i++)
            {
                sum += prices[route[i] - 1, route[i + 1] - 1];
            }
            return sum;
        }
    }
}
