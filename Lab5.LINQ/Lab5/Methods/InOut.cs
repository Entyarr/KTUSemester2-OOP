using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace Lab5.Methods
{
    /// <summary>
    /// Does all file managment and data reading stuff
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads files from directory
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <param name="pattern">Pattern of data files</param>
        /// <returns></returns>
        public static List<Warehouse> ReadDirectories(string directory, string pattern = "*Sandelis.txt")
        {
            List<Warehouse> warehouse = new List<Warehouse>();
            if (!Directory.Exists(directory)) { throw new Exception(string.Format("No directory found in {0}, reload and try again", directory)); }
            if (Directory.GetFiles(directory, pattern).Count() == 0) { throw new Exception(string.Format("No data files found in {0}, reload and try again", directory)); }
            foreach (var fileName in Directory.GetFiles(directory, pattern))
            {
                int warehouseNumber;
                
                using (StreamReader fin = new StreamReader(fileName))
                {
                    warehouseNumber = int.Parse(fin.ReadLine().Trim());
                }
                List<Wares> wares = ReadWares(fileName);
                warehouse.Add(new Warehouse(warehouseNumber, wares));


            }
            return warehouse;

        }
        /// <summary>
        /// Reads order
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns></returns>
        public static List<Wares> ReadWares(string fileName)
        {
            if (File.Exists("App_Data/Uzsakymas.txt")) { throw new Exception(string.Format("No order file found in {0}, reload and try again", fileName)); }
            List<Wares> wares = new List<Wares>();
            using (StreamReader fin = new StreamReader(fileName))
            {
                string line;
                while((line = fin.ReadLine()) != null)
                {
                    if (line.Contains(';'))
                    {
                        string[] parts = line.Split(';');
                        string name = parts[0].Trim();
                        int amount = int.Parse(parts[1].Trim());
                        decimal price = decimal.Parse(parts[2].Trim(), new CultureInfo("en-US"));
                        wares.Add(new Wares(name, amount, price));
                    }
                    
                }
            }
            return wares;

        }
        /// <summary>
        /// Prints all warehouses to txt file
        /// </summary>
        /// <param name="warehouse">Warehouses</param>
        /// <param name="fileName">Name of file</param>
        public static void PrintWarehouseData(List<Warehouse> warehouse, string fileName)
        {
            using(StreamWriter fout = new StreamWriter(fileName))
            {
                foreach(var w in warehouse)
                {
                    fout.WriteLine(w.Number);
                    fout.WriteLine(new string('-', 46));
                    fout.WriteLine("| {0,-20} | {1,8} | {2,8} |", "Prekė", "Kiekis", "Kaina");
                    fout.WriteLine(new string('-', 46));
                    foreach (var i in w.Items)
                    {
                        fout.WriteLine(i);
                    }
                    fout.WriteLine(new string('-', 46));
                    fout.WriteLine();
                }
            }
        }
        /// <summary>
        /// Prints a list of wares
        /// </summary>
        /// <param name="wares">Wares list</param>
        /// <param name="header">Header</param>
        /// <param name="fileName">Name of file</param>
        public static void PrintWares(List<Wares> wares, string header, string fileName)
        {
            using(StreamWriter fout = new StreamWriter(fileName, true))
            {
                fout.WriteLine(header);
                fout.WriteLine(new string('-', 46));
                fout.WriteLine("| {0,-20} | {1,8} | {2,8} |", "Prekė", "Kiekis", "Kaina");
                fout.WriteLine(new string('-', 46));
                foreach(var w in wares)
                {
                    fout.WriteLine(w);
                }
                fout.WriteLine(new string('-', 46));
                fout.WriteLine();
            }
        }
        /// <summary>
        /// Prints all unsold items with reason why
        /// </summary>
        /// <param name="wares">List of wares</param>
        /// <param name="header">Header</param>
        /// <param name="fileName">Name of file</param>
        public static void PrintUnsold(List<Wares> wares, string header, string fileName)
        {
            using(StreamWriter fout = new StreamWriter(fileName, true))
            {
                fout.WriteLine(header);
                fout.WriteLine(new string('-', 89));
                fout.WriteLine("| {0,-20} | {1,8} | {2,8} | {3,-40} |", "Prekė", "Kiekis", "Kaina", "Priežastis");
                fout.WriteLine(new string('-', 89));
                foreach (var w in wares)
                {
                    string price;
                    if (w.Price > 0.00m) price = w.Price.ToString();
                    else price = "Nėra";
                    fout.WriteLine("| {0,-20} | {1,8} | {2,8} | {3,-40} |", w.Item, w.Amount, price, w.info);
                }
                fout.WriteLine(new string('-', 89));
                fout.WriteLine();
            }
        }
    }
}