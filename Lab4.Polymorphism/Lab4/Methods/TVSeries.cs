using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Methods
{
    /// <summary>
    /// Defines TV series
    /// </summary>
    public class TVSeries : Record, IComparable<TVSeries>, IEquatable<TVSeries>
    {   
        public DateTime Start { get; set; }
        public int Seasons { get; set; }
        public DateTime End { get; set; }
        public bool Running { get; set; }

        public TVSeries(string title, string genre, string distributor, string actor1, string actor2, DateTime start, int seasons, DateTime end, bool running) : base(title, genre, distributor, actor1, actor2)
        {
            Start = start;
            Seasons = seasons;
            End = end;
            Running = running;
        }

        /// <summary>
        /// Overrides to string method to print string
        /// </summary>
        /// <returns>String to print</returns>
        public override string ToString()
        {
            string isRunning;
            if (Running)
            {
                isRunning = "-";
            }
            else isRunning = End.ToString("yyyy");
            return string.Join(";", Title, Genre, Distributor, Actor1, Actor2, Start.ToString("yyyy"), Seasons.ToString(), isRunning, Running.ToString());

        }
        
        /// <summary>
        /// Overrides Age method to find age of tv series
        /// </summary>
        /// <returns>Age of tv series</returns>
        public override int Age()
        {

            DateTime today = DateTime.Today;
            TimeSpan difference = today - Start;

            DateTime zeroTime = new DateTime(1, 1, 1);

            int years = (zeroTime + difference).Year - 1;
            return years;
            
        }
        /// <summary>
        /// Compares TV series to other series
        /// </summary>
        /// <param name="other">Other series</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(TVSeries other)
        {
            if (other is TVSeries)
            {
                if (Running && !other.Running) return -1;
                else if (Running && other.Running && Start > other.Start) return -1;
                else if (!Running && !other.Running && End > other.End) return -1;
                else if (!Running && !other.Running && End == other.End && Start > other.Start) return -1;
                else return 1;
            }
            else return 1;

        }
        /// <summary>
        /// Checks if our tv series is the same as other tv series
        /// </summary>
        /// <param name="other">Other tv series</param>
        /// <returns>True or false</returns>
        public bool Equals(TVSeries other)
        {
            if (Title == other.Title) return true;
            else return false;
        }

    }
}