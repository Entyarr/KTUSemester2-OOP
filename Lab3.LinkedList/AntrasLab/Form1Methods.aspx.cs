using AntrasLab.Methods;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntrasLab
{
    public partial class Form1 : System.Web.UI.Page
    {
        public void CustomersTable(Table table, LinkedList<Customer> customers)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Adresas" });
            header.Cells.Add(new TableCell { Text = "Pavarde" });
            header.Cells.Add(new TableCell { Text = "Numeris" });
            header.Cells.Add(new TableCell { Text = "Pranumeratos pradzios menuo" });
            header.Cells.Add(new TableCell { Text = "Pranumeratos ilgis (men)" });
            header.Cells.Add(new TableCell { Text = "Leidinio kodas" });
            header.Cells.Add(new TableCell { Text = "Leidiniu kiekis" });
            header.Cells.Add(new TableCell { Text = "Agento kodas" });
            table.Rows.Add(header);

            foreach (Customer c in customers)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = c.Address });
                row.Cells.Add(new TableCell { Text = c.LastName });
                row.Cells.Add(new TableCell { Text = c.Number });
                row.Cells.Add(new TableCell { Text = c.SubStart.ToString() });
                row.Cells.Add(new TableCell { Text = c.SubEnd.ToString() });
                row.Cells.Add(new TableCell { Text = c.SubCode });
                row.Cells.Add(new TableCell { Text = c.MagAmount.ToString() });
                row.Cells.Add(new TableCell { Text = c.AgentCode });
                table.Rows.Add(row);
            }
        }
        public void AgentsTable(Table table, LinkedList<Agent> agents)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Agento kodas" });
            header.Cells.Add(new TableCell { Text = "Pavarde" });
            header.Cells.Add(new TableCell { Text = "Vardas" });
            header.Cells.Add(new TableCell { Text = "Adresas" });
            header.Cells.Add(new TableCell { Text = "Numeris" });
            table.Rows.Add(header);

            foreach (Agent a in agents)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = a.AgentCode });
                row.Cells.Add(new TableCell { Text = a.LastName });
                row.Cells.Add(new TableCell { Text = a.Name });
                row.Cells.Add(new TableCell { Text = a.Address });
                row.Cells.Add(new TableCell { Text = a.Number });
                table.Rows.Add(row);
            }
        }
        public void MonthTable(Table table, LinkedList<CustomersByAgent> agents)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Agentas" });
            header.Cells.Add(new TableCell { Text = "Adresas" });
            header.Cells.Add(new TableCell { Text = "Pavarde" });
            header.Cells.Add(new TableCell { Text = "Numeris" });
            header.Cells.Add(new TableCell { Text = "Pranumeratos pradzios menuo" });
            header.Cells.Add(new TableCell { Text = "Pranumeratos ilgis (men)" });
            header.Cells.Add(new TableCell { Text = "Leidinio kodas" });
            header.Cells.Add(new TableCell { Text = "Leidiniu kiekis" });
            table.Rows.Add(header);

            foreach (CustomersByAgent a in agents)
            {
                foreach (Customer c in a.Customers)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = a.Agent });
                    row.Cells.Add(new TableCell { Text = c.Address });
                    row.Cells.Add(new TableCell { Text = c.LastName });
                    row.Cells.Add(new TableCell { Text = c.Number });
                    row.Cells.Add(new TableCell { Text = c.SubStart.ToString() });
                    row.Cells.Add(new TableCell { Text = c.SubEnd.ToString() });
                    row.Cells.Add(new TableCell { Text = c.SubCode });
                    row.Cells.Add(new TableCell { Text = c.MagAmount.ToString() });
                    table.Rows.Add(row);
                }
            }
        }
    }
}