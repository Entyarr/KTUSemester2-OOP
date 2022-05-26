using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Methods
{
    /// <summary>
    /// Creates abstract class for movies and TV series
    /// </summary>
    public abstract class Record
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Distributor { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public Record(string title, string genre, string distributor, string actor1, string actor2)
        {
            Title = title;
            Genre = genre;
            Distributor = distributor;
            Actor1 = actor1;
            Actor2 = actor2;
        }
        /// <summary>
        /// Creates abstract string method for printing CVS lines
        /// </summary>
        /// <returns>String to print</returns>
        public abstract string ToString();
        /// <summary>
        /// Creates abstract int method for finding age
        /// </summary>
        /// <returns>Age for the media</returns>
        public abstract int Age();
        /// <summary>
        /// Compares the two media
        /// </summary>
        /// <param name="obj">Other media</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return Title == ((Record)obj).Title;
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}