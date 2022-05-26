using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab4.Methods
{
    /// <summary>
    /// Works with input and output of all data
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads directories, finds all files and extracts all data from them
        /// </summary>
        /// <param name="directory">Directory location</param>
        /// <param name="pattern">What type of file</param>
        /// <returns>All data</returns>
        public static List<Watcher> ReadDirectories(string directory, string pattern = "*.txt")
        {
            List<Watcher> watchers = new List<Watcher>();
            if(!Directory.Exists(directory)) { throw new Exception(string.Format("No directory found in {0}", directory)); }
            if (Directory.GetFiles(directory, pattern).Count() == 0) { throw new Exception(string.Format("No data files found in {0}", directory)); }
            foreach (var fileName in Directory.GetFiles(directory, pattern))
            {
                string name;
                DateTime birth;
                string city;
                using(StreamReader fin = new StreamReader(fileName))
                {
                    name = fin.ReadLine().Trim();
                    birth = DateTime.Parse(fin.ReadLine().Trim());
                    city = fin.ReadLine().Trim();
                }
                List<Record> records = new List<Record>();
                records = ReadRecords(fileName);
                watchers.Add(new Watcher(name, birth, city, records));
            }
            return watchers;

        }
        /// <summary>
        /// Reads data from a single file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>All records from a data file</returns>
        public static List<Record> ReadRecords(string fileName)
        {
            List<Record> records = new List<Record>();
            using(StreamReader fin = new StreamReader(fileName))
            {
                for (int i = 0; i < 3; i++) fin.ReadLine(); //Skips the first 3 lines of the file
                string line;
                while ((line = fin.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string title = parts[0].Trim();
                    string genre = parts[1].Trim();
                    string distributor = parts[2].Trim();
                    string actor1 = parts[3].Trim();
                    string actor2 = parts[4].Trim();

                    if (parts.Length < 8 || parts.Length > 9) { throw new Exception(string.Format("Wrong format in {0} in {1}", fileName, line)); }

                    if (parts.Length == 8)
                    {
                        //Film
                        
                        DateTime release = DateTime.ParseExact(parts[5].Trim(), "yyyy", null);
                        string director = parts[6].Trim();
                        int budget = int.Parse(parts[7].Trim());
                        records.Add(new Film(title, genre, distributor, actor1, actor2, release, director, budget));
                    }
                    else if(parts.Length == 9)
                    {
                        //TVSeries

                        DateTime start = DateTime.ParseExact(parts[5].Trim(), "yyyy", null);
                        int seasons = int.Parse(parts[6].Trim());

                        DateTime end;
                        bool running = false;
                        
                        if (parts[7].Trim() == "") { end = new DateTime(9999, 12, 31); }
                        else { end = DateTime.ParseExact(parts[7].Trim(), "yyyy", null); }

                        if (parts[8].Trim() == "ne") { running = false; }
                        else if(parts[8].Trim() == "taip") { running = true; }

                        records.Add(new TVSeries(title, genre, distributor, actor1, actor2, start, seasons, end, running));
                    }
                }
            }
            return records;
        }

        /// <summary>
        /// Prints data to a file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="watchers">All data</param>
        public static void PrintStartData(string fileName, List<Watcher> watchers)
        {
            using(StreamWriter fout = new StreamWriter(fileName))
            {
                foreach(var watcher in watchers)
                {
                    fout.WriteLine(watcher.Name);
                    fout.WriteLine("{0:yyyy-MM-dd}", watcher.Birth);
                    fout.WriteLine(watcher.City);
                    fout.WriteLine(new string('-', 50));
                    
                    foreach(var record in watcher.Media)
                    {
                        fout.WriteLine(record);
                    }
                    fout.WriteLine(new string('-', 50));
                    fout.WriteLine();
                }
            }
        }

        /// <summary>
        /// Prints movies and tv series
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="records">Movies and tv series</param>
        public static void PrintMedia(string fileName, List<Record> records)
        {
            using(StreamWriter fout = new StreamWriter(fileName))
            {
                foreach(var r in records)
                {
                    fout.WriteLine(r.ToString());
                }
            }
        }

        /// <summary>
        /// Prints recommendations for each watcher
        /// </summary>
        /// <param name="fileLocation">Location of a file</param>
        /// <param name="watchers">List of watchers with recommended media</param>
        public static void PrintRecommendations(string fileLocation, List<Watcher> watchers)
        {
            foreach(var w in watchers)
            {
                string fileName = fileLocation + w.PersonalRecommendation();
                using(StreamWriter fout = new StreamWriter(fileName))
                {
                    fout.WriteLine(w.Name);
                    fout.WriteLine("{0:yyyy-MM-dd}", w.Birth);
                    fout.WriteLine(w.City);
                    fout.WriteLine(new string('-', 50));
                    
                    foreach(var m in w.Media)
                    {
                        fout.WriteLine(m.Title);
                    }
                }
            }
        
        }
        /// <summary>
        /// Prints films and tv series in seperate formats
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="films">List of films</param>
        /// <param name="series">List of series</param>
        public static void PrintSeperated(string fileName, List<Film> films, List<TVSeries> series)
        {
            using(StreamWriter fout = new StreamWriter(fileName))
            {
                fout.WriteLine("Filmai:");
                foreach(var f in films)
                {
                    fout.WriteLine(f.ToString());
                }
                fout.WriteLine();
                fout.WriteLine("Serialai:");
                foreach(var s in series)
                {
                    fout.WriteLine(s.ToString());
                }
            }
        }
    }
}