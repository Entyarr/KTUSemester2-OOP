using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Methods
{
    /// <summary>
    /// Where all calculations and findings are done
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Finds pairs of watchers and their favorite actors
        /// </summary>
        /// <param name="watcher">List of watchers with their media</param>
        /// <returns>Watcher with favorite actor</returns>
        public static Dictionary<string, string> FavoriteActors(List<Watcher> watcher)
        {
            Dictionary<string, string> faveActor = new Dictionary<string, string>();

            ///Runs loop through all watchers
            foreach(var w in watcher)
            {
                Dictionary<string, int> actors = new Dictionary<string, int>();
                ///Runs loop through all media of a watcher
                foreach(var m in w.Media)
                {
                    if (actors.ContainsKey(m.Actor1)) actors[m.Actor1]++;
                    else actors.Add(m.Actor1, 1);
                    if (actors.ContainsKey(m.Actor2)) actors[m.Actor2]++;
                    else actors.Add(m.Actor2, 1);
                }
                faveActor.Add(w.Name, KeyOfMaxValue(actors));   
            }
            return faveActor;
        }

        /// <summary>
        /// Finds which key has the highest int value
        /// </summary>
        /// <param name="dict">Dictionary with string and int</param>
        /// <returns>Key with highest value</returns>
        public static string KeyOfMaxValue(Dictionary<string, int> dict)
        {
            KeyValuePair<string, int> max = new KeyValuePair<string, int>(null, -1);
            foreach(var item in dict)
            {
                if(item.Value > max.Value)
                {
                    max = new KeyValuePair<string, int>(item.Key, item.Value);
                }
            }
            return max.Key;
        }

        /// <summary>
        /// Finds all movies and tv series and compiles them in a single list
        /// </summary>
        /// <param name="watchers">All data with watchers</param>
        /// <returns>All media</returns>
        public static List<Record> GetAllMedia(List<Watcher> watchers)
        {
            List<Record> media = new List<Record>();

            foreach(var w in watchers)
            {
                foreach(var m in w.Media)
                {
                    if (media.Contains(m)) continue;
                    else media.Add(m);
                }
            }
            return media;
        }

        /// <summary>
        /// Finds movies or tv series that every watcher has seen
        /// </summary>
        /// <param name="allRecords">All movies and tv series</param>
        /// <param name="watchers">All data</param>
        /// <returns>List of media everyone saw</returns>
        public static List<Record> EveryoneSaw(List<Record> allRecords, List<Watcher> watchers)
        {
            List<Record> popular = new List<Record>();

            foreach(var r in allRecords)
            {
                int count = 0;
                foreach(var w in watchers)
                {
                    if (w.Media.Contains(r)) count++;
                }

                if (count == watchers.Count())
                {
                    popular.Add(r);
                }
            }
            return popular;
        }

        /// <summary>
        /// Finds movies and tv series each watcher has not seen and assigns them to the watcher
        /// </summary>
        /// <param name="allRecords">All media</param>
        /// <param name="watchers">All data</param>
        /// <returns>List of watchers with recommended media</returns>
        public static List<Watcher> Recommendations(List<Record> allRecords, List<Watcher> watchers)
        {
            List<Watcher> recommended = new List<Watcher>();

            foreach(var w in watchers)
            {
                string name = w.Name;
                DateTime birth = w.Birth;
                string city = w.City;

                List<Record> records = new List<Record>();

                foreach(var r in allRecords)
                {
                    if (!w.Media.Contains(r)) records.Add(r);
                }

                recommended.Add(new Watcher(name, birth, city, records));
            }

            return recommended;
        }

        /// <summary>
        /// Finds which movies and tv shows are new
        /// </summary>
        /// <param name="allMedia">All media</param>
        /// <returns>New movies and tv shows</returns>
        public static List<Record> GetNewMedia(List<Record> allMedia)
        {
            List<Record> newMedia = new List<Record>();

            foreach (var m in allMedia)
            {
                if(m is Film && m.Age() <= 2)
                {
                    newMedia.Add(m); 
                }
                else if(m is TVSeries && m.Age() <= 1)
                { 
                    newMedia.Add(m);
                }
            }

            return newMedia;
        }

        /// <summary>
        /// Filters all movies out of the master list of movies and tv series
        /// </summary>
        /// <param name="media">All media</param>
        /// <returns>List of movies</returns>
        public static List<Film> FilterMovies(List<Record> media)
        {
            List<Film> films = new List<Film>();
            foreach(var m in media)
            {
                if (m is Film) films.Add(m as Film);
            }
            return films;
        }
        /// <summary>
        /// Filters all tv series out of the master list of movies and tv series
        /// </summary>
        /// <param name="media">All media</param>
        /// <returns>List of TV series</returns>
        public static List<TVSeries> FilterTVSeries(List<Record> media)
        {
            List<TVSeries> series = new List<TVSeries>();
            foreach (var m in media)
            {
                if (m is TVSeries) series.Add(m as TVSeries);
            }
            return series;
        }

    }
}