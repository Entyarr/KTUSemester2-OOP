using Lab4.Methods;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4
{
    public partial class Form1 : System.Web.UI.Page
    {
        public void DataTable(Table table, List<Watcher> watchers)
        {
            table.Rows.Clear();
            foreach(var w in watchers)
            {
                TableRow watcher = new TableRow();
                string person = string.Format("{0} <br/> {1:yyyy-MM-dd} <br/> {2}", w.Name, w.Birth, w.City);
                watcher.Cells.Add(new TableCell { Text = person, ColumnSpan = 5 });
                table.Rows.Add(watcher);

                TableRow header = new TableRow();
                header.Cells.Add(new TableCell { Text = "Pavadinimas" });
                header.Cells.Add(new TableCell { Text = "Zanras" });
                header.Cells.Add(new TableCell { Text = "Kino Studija" });
                header.Cells.Add(new TableCell { Text = "Pirmas aktorius" });
                header.Cells.Add(new TableCell { Text = "Antras aktorius" });
                table.Rows.Add(header);

                foreach(var m in w.Media)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = m.Title });
                    row.Cells.Add(new TableCell { Text = m.Genre });
                    row.Cells.Add(new TableCell { Text = m.Distributor });
                    row.Cells.Add(new TableCell { Text = m.Actor1 });
                    row.Cells.Add(new TableCell { Text = m.Actor2 });
                    table.Rows.Add(row);
                }
                TableRow empty = new TableRow();
                empty.Cells.Add(new TableCell { Text = ".", ColumnSpan = 5, BackColor = System.Drawing.ColorTranslator.FromHtml("#424242") });
                table.Rows.Add(empty);
            }
        }

        public void FavoriteActorsTable(Table table, Dictionary<string, string> faveActors)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Asmuo" });
            header.Cells.Add(new TableCell { Text = "Aktorius" });
            table.Rows.Add(header);

            foreach(KeyValuePair<string, string> kvp in faveActors)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = kvp.Key });
                row.Cells.Add(new TableCell { Text = kvp.Value });
                table.Rows.Add(row);
            }
        }

        public void AllSeenTable(Table table, List<Record> records)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Pavadinimas" });
            header.Cells.Add(new TableCell { Text = "Zanras" });
            header.Cells.Add(new TableCell { Text = "Kino Studija" });
            header.Cells.Add(new TableCell { Text = "Pirmas aktorius" });
            header.Cells.Add(new TableCell { Text = "Antras aktorius" });
            table.Rows.Add(header);

            foreach (var r in records)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = r.Title });
                row.Cells.Add(new TableCell { Text = r.Genre });
                row.Cells.Add(new TableCell { Text = r.Distributor });
                row.Cells.Add(new TableCell { Text = r.Actor1 });
                row.Cells.Add(new TableCell { Text = r.Actor2 });
                table.Rows.Add(row);
            }
        }

        public void RecommendationsTable(Table table, List<Watcher> watchers)
        {
            table.Rows.Clear();
            foreach (var w in watchers)
            {
                TableRow watcher = new TableRow();
                string person = string.Format("{0} <br/> {1:yyyy-MM-dd} <br/> {2}", w.Name, w.Birth, w.City);
                watcher.Cells.Add(new TableCell { Text = person});
                table.Rows.Add(watcher);

                TableRow header = new TableRow();
                header.Cells.Add(new TableCell { Text = "Pavadinimas" });
                table.Rows.Add(header);

                foreach (var m in w.Media)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = m.Title });
                    table.Rows.Add(row);
                }
                TableRow empty = new TableRow();
                empty.Cells.Add(new TableCell { Text = ".", BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")});
                table.Rows.Add(empty);
            }
        }

        public void NewMediaTable(Table table, List<Film> films, List<TVSeries> series)
        {
            table.Rows.Clear();
            TableRow movies = new TableRow();
            movies.Cells.Add(new TableCell { Text = "Filmai", ColumnSpan = 9 });
            table.Rows.Add(movies);

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Pavadinimas", ColumnSpan = 2});
            header.Cells.Add(new TableCell { Text = "Zanras" });
            header.Cells.Add(new TableCell { Text = "Kino Studija" });
            header.Cells.Add(new TableCell { Text = "Pirmas aktorius" });
            header.Cells.Add(new TableCell { Text = "Antras aktorius" });
            header.Cells.Add(new TableCell { Text = "Metai" });
            header.Cells.Add(new TableCell { Text = "Rezisierius" });
            header.Cells.Add(new TableCell { Text = "Biudzetas" });
            table.Rows.Add(header);

      

            foreach (var f in films)
            {
                TableRow dataMovies = new TableRow();
                dataMovies.Cells.Add(new TableCell { Text = f.Title, ColumnSpan = 2 });
                dataMovies.Cells.Add(new TableCell { Text = f.Genre });
                dataMovies.Cells.Add(new TableCell { Text = f.Distributor });
                dataMovies.Cells.Add(new TableCell { Text = f.Actor1 });
                dataMovies.Cells.Add(new TableCell { Text = f.Actor2 });
                dataMovies.Cells.Add(new TableCell { Text = f.Release.ToString("yyyy") });
                dataMovies.Cells.Add(new TableCell { Text = f.Director });
                dataMovies.Cells.Add(new TableCell { Text = f.Budget.ToString() });
                table.Rows.Add(dataMovies);
            }

            TableRow empty = new TableRow();
            empty.Cells.Add(new TableCell { Text = ".", BackColor = System.Drawing.ColorTranslator.FromHtml("#424242"), ColumnSpan = 9 });
            table.Rows.Add(empty);

            TableRow TVseries = new TableRow();
            TVseries.Cells.Add(new TableCell { Text = "Serialai", ColumnSpan = 9 });
            table.Rows.Add(TVseries);

            TableRow headerSeries = new TableRow();
            headerSeries.Cells.Add(new TableCell { Text = "Pavadinimas" });
            headerSeries.Cells.Add(new TableCell { Text = "Zanras" });
            headerSeries.Cells.Add(new TableCell { Text = "Kino Studija" });
            headerSeries.Cells.Add(new TableCell { Text = "Pirmas aktorius" });
            headerSeries.Cells.Add(new TableCell { Text = "Antras aktorius" });
            headerSeries.Cells.Add(new TableCell { Text = "Pirmo sezono matai" });
            headerSeries.Cells.Add(new TableCell { Text = "Sezonu kiekis" });
            headerSeries.Cells.Add(new TableCell { Text = "Seriju pabaigos metai" });
            headerSeries.Cells.Add(new TableCell { Text = "Ar tesiasi?" });
            table.Rows.Add(headerSeries);

            foreach (var s in series)
            {
                TableRow dataSeries = new TableRow();
                dataSeries.Cells.Add(new TableCell { Text = s.Title });
                dataSeries.Cells.Add(new TableCell { Text = s.Genre });
                dataSeries.Cells.Add(new TableCell { Text = s.Distributor });
                dataSeries.Cells.Add(new TableCell { Text = s.Actor1 });
                dataSeries.Cells.Add(new TableCell { Text = s.Actor2 });
                dataSeries.Cells.Add(new TableCell { Text = s.Start.ToString("yyyy") });
                dataSeries.Cells.Add(new TableCell { Text = s.Seasons.ToString() });

                string endDate;
                if (s.Running) endDate = "-";
                else endDate = s.End.ToString("yyyy");

                dataSeries.Cells.Add(new TableCell { Text = endDate });

                string running;
                if (s.Running) running = "Tesiasi";
                else running = "Nesitesia";

                dataSeries.Cells.Add(new TableCell { Text = running});
                table.Rows.Add(dataSeries);
            }


        }
    }
}