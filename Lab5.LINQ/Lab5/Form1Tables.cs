using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab5.Methods;

namespace Lab5
{
    public partial class Form1 : System.Web.UI.Page
    {
        /// <summary>
        /// Prints wares onto a table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="wares"></param>
        public void SellingWaresTable(Table table, List<Wares> wares)
        {
            table.Rows.Clear();
            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Prekė" });
            header.Cells.Add(new TableCell { Text = "Kiekis" });
            header.Cells.Add(new TableCell { Text = "Kaina" });
            table.Rows.Add(header);

            foreach(var w in wares)
            {
                TableRow items = new TableRow();
                items.Cells.Add(new TableCell { Text = w.Item });
                items.Cells.Add(new TableCell { Text = w.Amount.ToString() });
                items.Cells.Add(new TableCell { Text = w.Price.ToString() });
                table.Rows.Add(items);
            }

            TableRow totalPrice = new TableRow();
            decimal price = wares.Sum(x => x.Price * x.Amount);
            totalPrice.Cells.Add(new TableCell { Text = "Bendra kaina: " + price, ColumnSpan = 3 });
            table.Rows.Add(totalPrice);

        }
        /// <summary>
        /// Prints all unsold items with reasons
        /// </summary>
        /// <param name="table"></param>
        /// <param name="wares"></param>
        public void UnsoldTable(Table table, List<Wares> wares)
        {
            table.Rows.Clear();
            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Prekė" });
            header.Cells.Add(new TableCell { Text = "Kiekis" });
            header.Cells.Add(new TableCell { Text = "Kaina" });
            header.Cells.Add(new TableCell { Text = "Priežastis" });
            table.Rows.Add(header);

            foreach (var w in wares)
            {
                string price;
                if (w.Price > 0.00m) price = w.Price.ToString();
                else price = "Nėra";
                TableRow items = new TableRow();
                items.Cells.Add(new TableCell { Text = w.Item });
                items.Cells.Add(new TableCell { Text = w.Amount.ToString() });
                items.Cells.Add(new TableCell { Text = price });
                items.Cells.Add(new TableCell { Text = w.info });
                table.Rows.Add(items);
            }

        }
        /// <summary>
        /// Prints all data onto a table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="warehouse"></param>
        public void AllDataTable(Table table, List<Warehouse> warehouse)
        {
            table.Rows.Clear();
            foreach (var w in warehouse)
            {
                TableRow number = new TableRow();
                number.Cells.Add(new TableCell { Text = w.Number.ToString(), ColumnSpan = 3 });
                table.Rows.Add(number);

                TableRow header = new TableRow();
                header.Cells.Add(new TableCell { Text = "Prekė" });
                header.Cells.Add(new TableCell { Text = "Kiekis" });
                header.Cells.Add(new TableCell { Text = "Kaina" });
                table.Rows.Add(header);

                foreach (var i in w.Items)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = i.Item });
                    row.Cells.Add(new TableCell { Text = i.Amount.ToString() });
                    row.Cells.Add(new TableCell { Text = i.Price.ToString() });
                    table.Rows.Add(row);
                }
                TableRow empty = new TableRow();
                empty.Cells.Add(new TableCell { Text = ".", ColumnSpan = 3, BackColor = System.Drawing.ColorTranslator.FromHtml("#424242") });
                table.Rows.Add(empty);
            }
        }
    }
}