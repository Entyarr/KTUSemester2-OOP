using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AntrasLab.Methods
{
    /// <summary>
    /// Does all things related to files
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads agents from file
        /// </summary>
        /// <param name="filename">Name of file</param>
        /// <returns>Linked list of agents</returns>
        public static AgentList ReadAgents(string filename)
        {
            string[] Lines = File.ReadAllLines(filename);
            AgentList agents = new AgentList();
            foreach (string line in Lines)
            {
                string[] parts = line.Split(';');
                string agentCode = parts[0];
                string lastName = parts[1];
                string name = parts[2];
                string address = parts[3];
                string number = parts[4];
                agents.AddToEnd(new Agent(agentCode, lastName, name, address, number));
            }
            return agents;
        }
        /// <summary>
        /// Reads customers from a file
        /// </summary>
        /// <param name="filename">name of file</param>
        /// <returns>Linked list of customers</returns>
        public static CustomerList ReadCustomers(string filename)
        {
            string[] Lines = File.ReadAllLines(filename);
            CustomerList customers = new CustomerList();
            foreach (string line in Lines)
            {
                string[] parts = line.Split(';');
                string address = parts[0];
                string lastName = parts[1];
                string number = parts[2];
                int start = int.Parse(parts[3]);
                int end = int.Parse(parts[4]);
                string subCode = parts[5];
                int magCount = int.Parse(parts[6]);
                string agentCode = parts[7];
                customers.AddToEnd(new Customer(address, lastName, number, start, end, subCode, magCount, agentCode));
            }
            return customers;
        }
        /// <summary>
        /// Creates an empty file
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateOutFile(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }
        /// <summary>
        /// Prints customers to a TXT file
        /// </summary>
        /// <param name="customers">List of customers</param>
        /// <param name="fileName">File name</param>
        /// <param name="header">Title of box</param>
        public static void PrintCustomers(CustomerList customers, string fileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', 104));
                writer.WriteLine("| {0, -104} |", header);
                writer.WriteLine(new string('-', 100));
                writer.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,7} | {4,6} | {5,-8} | {6,6} | {7,-12} |", 
                                 "Adresas", "Pavarde", "Numeris", "Pradzia", "Trukme", "Leidinys", "Kiekis", "Agento kodas");
                writer.WriteLine(new string('-', 104));
                foreach (Customer c in customers)
                {
                    writer.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,7} | {4,6} | {5,-8} | {6,6} | {7,-12} |",
                                     c.Address, c.LastName, c.Number, c.SubStart, c.SubEnd, c.SubCode, c.MagAmount, c.AgentCode);
                }
                writer.WriteLine(new string('-', 104));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Prints agents to a TXT file
        /// </summary>
        /// <param name="agents">List of agents</param>
        /// <param name="fileName">File name</param>
        /// <param name="header">Title of the box</param>
        public static void PrintAgents(AgentList agents, string fileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', 76));
                writer.WriteLine("| {0, -72} |", header);
                writer.WriteLine(new string('-', 76));
                writer.WriteLine("| {0,-12} | {1,-15} | {2,-8} | {3,-15} | {4,-10} |",
                                 "Agento kodas", "Pavarde", "Vardas", "Adresas", "Numeris");
                writer.WriteLine(new string('-', 76));
                foreach (Agent a in agents)
                {
                    writer.WriteLine("| {0,-12} | {1,-15} | {2,-8} | {3,-15} | {4,-10} |",
                                         a.AgentCode, a.LastName, a.Name, a.Address, a.Number);
                }
                writer.WriteLine(new string('-', 76));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Prints master list of agents and their customers to TXT file
        /// </summary>
        /// <param name="agents">List of lists</param>
        /// <param name="fileName">File name</param>
        /// <param name="header">Title of box</param>
        public static void PrintMasterList(CustomersByAgentList agents, string fileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', 112));
                writer.WriteLine("| {0, -108} |", header);
                writer.WriteLine(new string('-', 112));
                writer.WriteLine("| {0,-20} | {1,-15} | {2,-15} | {3,-10} | {4,7} | {5,6} | {6,-8} | {7,6} |",
                                 "Agentas", "Adresas", "Pavarde", "Numeris", "Pradzia", "Trukme", "Leidinys", "Kiekis");
                writer.WriteLine(new string('-', 112));
                if (agents.Count() > 0)
                {
                    foreach (CustomersByAgent a in agents)
                    {
                        foreach (Customer c in a.Customers)
                        {
                            writer.WriteLine("| {0,-20} | {1,-15} | {2,-15} | {3,-10} | {4,7} | {5,6} | {6,-8} | {7,6} |",
                                             a.Agent, c.Address, c.LastName, c.Number, c.SubStart, c.SubEnd, c.SubCode, c.MagAmount);
                        }
                    }
                }
                writer.WriteLine(new string('-', 112));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Prints a line of text related to the magazine count
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <param name="text">Text to print</param>
        /// <param name="MagCount">Magazine count</param>
        public static void PrintMagazineText(string fileName, string text, int MagCount)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text + " " + MagCount);
                writer.WriteLine();
            }
        }
    }
}
