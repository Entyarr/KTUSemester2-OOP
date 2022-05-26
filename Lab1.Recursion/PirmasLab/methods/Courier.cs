using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PirmasLab.methods
{
    /// <summary>
    /// Courier object
    /// </summary>
    public class Courier
    {
        /// <summary>
        /// Amount of points
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Price map between all points
        /// </summary>
        public int[,] Prices { get; set; }
        /// <summary>
        /// Price mapp between all points
        /// </summary>
        public int[] Route { get; set; }

        /// <summary>
        /// Creates object for routes
        /// </summary>
        /// <param name="count">Amount of points</param>
        /// <param name="prices">Price map between all points</param>
        public Courier(int count, int[,] prices)
        {
            this.Count = count;
            this.Prices = prices;
            this.Route = firstRoute(Count);

        }


        /// <summary>
        /// Creates the initial route, that will be edited into various routes
        /// </summary>
        /// <param name="count">Amount of points</param>
        /// <returns>Array of initial route</returns>
        private int[] firstRoute(int count)
        {
            int[] points = new int[count + 1];
            for (int i = 0; i < count; i++)
            {
                points[i] = i + 1;
            }
            points[count] = 1;

            return points;
        }

    }
}