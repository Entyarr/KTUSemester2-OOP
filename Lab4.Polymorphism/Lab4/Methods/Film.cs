using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab4.Methods
{
    /// <summary>
    /// Defines a film
    /// </summary>
    public class Film : Record, IComparable<Film>, IEquatable<Film>
    {
        public DateTime Release { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }
        public Film(string title, string genre, string distributor, string actor1, string actor2, DateTime release, string director, int budget) : base(title, genre, distributor, actor1, actor2)
        {
            Release = release;
            Director = director;
            Budget = budget;
        }
        /// <summary>
        /// Creates string for easy printing
        /// </summary>
        /// <returns>String to print</returns>
        public override string ToString()
        {
            return string.Join(";", Title, Genre, Distributor, Actor1, Actor2, Release.ToString("yyyy"), Director, Budget.ToString());
        }
        /// <summary>
        /// Calculates age of the movie
        /// </summary>
        /// <returns>Age of movie</returns>
        public override int Age()
        {
            DateTime today = DateTime.Today;
            TimeSpan difference = today - Release;

            DateTime zeroTime = new DateTime(1, 1, 1);

            int years = (zeroTime + difference).Year - 1;
            return years;
         
        }

        /// <summary>
        /// Compares two objects by given data
        /// </summary>
        /// <param name="other">Other film</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(Film other)
        {
            if (other is Film)
            {
                if (Budget > other.Budget) return -1;
                else return 1;
            }
            else return -1;
        }

        /// <summary>
        /// Checks if other object is equal to our object
        /// </summary>
        /// <param name="other">Other film</param>
        /// <returns>True or false</returns>
        public bool Equals(Film other)
        {
            if (Title == other.Title) return true;
            else return false;
        }

    }
}