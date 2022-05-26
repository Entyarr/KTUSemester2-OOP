using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab4.Methods;

namespace Lab4
{
    public partial class Form1 : System.Web.UI.Page
    {
        private List<Watcher> watchers = new List<Watcher>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                watchers = InOut.ReadDirectories(Server.MapPath("App_Data"));
            }
            catch(Exception except)
            {
                throw except;
            }
            InOut.PrintStartData(Server.MapPath("App_Data/WatchersData.csv"), watchers);
            DataTable(Table1, watchers);

            Label1.Visible = false;
            Table1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Table1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            
            Dictionary<string, string> faveActors = TaskUtils.FavoriteActors(watchers);
            FavoriteActorsTable(Table2, faveActors);

            List<Record> allMedia = TaskUtils.GetAllMedia(watchers);

            List<Record> allSeen = TaskUtils.EveryoneSaw(allMedia, watchers);
            AllSeenTable(Table3, allSeen);
            InOut.PrintMedia(Server.MapPath("App_Data/MateVisi.csv"), allSeen);

            List<Watcher> recommendations = TaskUtils.Recommendations(allMedia, watchers);
            RecommendationsTable(Table4, recommendations);
            InOut.PrintRecommendations(Server.MapPath("App_Data"), recommendations);

            List<Record> newMedia = TaskUtils.GetNewMedia(allMedia);
            List<Film> newFilms = TaskUtils.FilterMovies(newMedia);
            List<TVSeries> newSeries = TaskUtils.FilterTVSeries(newMedia);

            newFilms.Sort();
            newSeries.Sort();

            NewMediaTable(Table5, newFilms, newSeries);
            InOut.PrintSeperated(Server.MapPath("App_Data/Nauji.csv"), newFilms, newSeries);
        }
    }
}