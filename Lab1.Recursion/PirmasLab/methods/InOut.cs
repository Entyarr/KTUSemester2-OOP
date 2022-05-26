using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PirmasLab.methods
{
    /// <summary>
    /// Class for working with text files
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads data from text file
        /// </summary>
        /// <param name="file">File location and name</param>
        /// <returns>Courier object with data taken from file</returns>
        public static Courier ReadTXT(string file)
        {
            using (StreamReader fin = new StreamReader(file))
            {
                int count = int.Parse(fin.ReadLine());
                int[,] prices = new int[count, count];
                for (int i = 0; i < count; i++)
                {
                    string line = fin.ReadLine();
                    string[] pricesString = line.Split(' ');

                    for (int j = 0; j < count; j++)
                    {
                        prices[i, j] = int.Parse(pricesString[j]);
                    }
                }

                Courier routes = new Courier(count, prices);
                return routes;
            }

        }

        /// <summary>
        /// Prints results to text file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="text"></param>
        public static void PrintTXT(string file, List<int> routes, int cheapestPrice)
        {
            using(StreamWriter fout = new StreamWriter(file))
            {
                string routesString = string.Join(" -> ", routes);
                string text = string.Format("Optimaliausias maršrutas: {0}. Maršruto išlaidos: {1}", routesString, cheapestPrice);

                fout.WriteLine(text);
            }
        }
    }
}