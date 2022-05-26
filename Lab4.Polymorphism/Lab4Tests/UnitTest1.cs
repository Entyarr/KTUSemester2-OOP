using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Lab4.Methods;

namespace Lab4Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestFindFavoriteActor()
        {
            List<Watcher> watchers = new List<Watcher>(); 
            List<Lab4.Methods.Record> media = new List<Lab4.Methods.Record>();
            media.Add(new Film("AAA", "BBB", "CCC", "ZZZ", "LLL", DateTime.Now, "DDD", 5000));
            media.Add(new Film("AAA", "BBB", "CCC", "MMM", "ZZZ", DateTime.Now, "DDD", 5000));
            watchers.Add(new Watcher("GREG", DateTime.Now, "GREG", media));
            Dictionary<string, string> faveActorsPair = TaskUtils.FavoriteActors(watchers);

            Dictionary<string, string> Result = new Dictionary<string, string>();
            Result.Add("GREG", "ZZZ");
            faveActorsPair.Should().BeEquivalentTo(Result);
        }


        [Fact]
        public void FindMaxKeyOfKeyValuePair()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("GREG", 1);
            dict.Add("JOHN", 2);
            dict.Add("BEST", 5);
            dict.Add("ANSWER", 9);
            dict.Add("TEST", 1);
            string Result = TaskUtils.KeyOfMaxValue(dict);
            Result.Should().Be("ANSWER");
        }

        [Fact]
        public void TestFindFilms()
        {
            List<Lab4.Methods.Record> media = new List<Lab4.Methods.Record>();
            Film testThing = new Film("AAA", "BBB", "CCC", "ZZZ", "LLL", DateTime.Now, "DDD", 5000);
            media.Add(testThing);
            media.Add(new TVSeries("GGG", "RRR", "BBB", "MMM", "ZZZ", DateTime.Now, 5, DateTime.Now, false));


            List<Film> result = TaskUtils.FilterMovies(media);
            result[0].Should().Be(testThing);
        }

        [Fact]
        public void TestFindSeries()
        {
            List<Lab4.Methods.Record> media = new List<Lab4.Methods.Record>();
            TVSeries testThing = new TVSeries("GGG", "RRR", "BBB", "MMM", "ZZZ", DateTime.Now, 5, DateTime.Now, false);
            media.Add(new Film("AAA", "BBB", "CCC", "ZZZ", "LLL", DateTime.Now, "DDD", 5000));
            media.Add(testThing);


            List<TVSeries> result = TaskUtils.FilterTVSeries(media);
            result[0].Should().Be(testThing);
        }
    }
}
