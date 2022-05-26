using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Methods
{
    /// <summary>
    /// Defines a watcher with their own list of movies they've see
    /// </summary>
    public class Watcher : IComparable<Watcher>, IEquatable<Watcher>
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string City { get; set; }
        public List<Record> Media { get; set; }

        public Watcher(string name, DateTime birth, string city, List<Record> media)
        {
            Name = name;
            Birth = birth;
            City = city;
            Media = media;
        }
        /// <summary>
        /// Returns string for a file name for each watcher
        /// </summary>
        /// <returns>String for file name</returns>
        public string PersonalRecommendation()
        {
            string[] nameParts = Name.Split(' ');
            return string.Format("/Rekomendacija_{0}_{1}.csv", nameParts[0].Trim(), nameParts[1].Trim());
        }
        /// <summary>
        /// Compares our watcher to other watcher
        /// </summary>
        /// <param name="other">Other watcher</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(Watcher other)
        {
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Compares our watcher to other watcher
        /// </summary>
        /// <param name="other">Other watcher</param>
        /// <returns>True or false</returns>
        public bool Equals(Watcher other)
        {
            return Name.Equals(other.Name);
        }
    }
}