using PirmasLab.methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PirmasLab
{
    public partial class forma1 : System.Web.UI.Page
    {
        private string inputFilename;
        private string outputFilename;
        private Courier courier;
        /// <summary>
        /// Load files, create a courier object
        /// </summary>
        /// <param name="sender">Sender element</param>
        /// <param name="e">Event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            inputFilename = Server.MapPath(@"App_Data/U3.txt");
            outputFilename = Server.MapPath(@"App_Data/Rezultatai.txt");
            courier = InOut.ReadTXT(inputFilename);
        }
        /// <summary>
        /// On button click, finds the optimal route and its price.
        /// </summary>
        /// <param name="sender">Sender element</param>
        /// <param name="e">Event</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            ///Creates routes and cheapest price variables
            List<int> routes = new List<int>();
            int cheapestPrice = int.MaxValue;

            
            TaskUtils.Task(courier, 1, courier.Route.Length - 1, ref routes, ref cheapestPrice);

            string routesString = string.Join(", ", routes);
            string text = string.Format("{0} = {1}", routesString, cheapestPrice);

            TextBox1.Text = text;

            InOut.PrintTXT(outputFilename, routes, cheapestPrice);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}