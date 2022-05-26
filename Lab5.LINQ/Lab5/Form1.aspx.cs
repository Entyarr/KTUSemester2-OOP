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
        private List<Warehouse> warehouse = new List<Warehouse>();
        private List<Wares> order;

        private List<Wares> waresAskedItems = new List<Wares>();


        private List<Wares> priceUnderOver;
        private List<Wares> wareOutOfStock;
        private Tuple<List<Wares>, List<Wares>> waresSoldUnsold;


        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            TextBox1.Visible = false;
            Button2.Visible = false;
            Label4.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            try
            {
                warehouse = InOut.ReadDirectories(Server.MapPath("App_Data"));
                order = InOut.ReadWares(Server.MapPath("App_Data/Uzsakymas.txt"));
                InOut.PrintWarehouseData(warehouse, Server.MapPath("App_Data/Result.txt"));

            }
            catch(Exception except)
            {
                Label8.Text = except.Message;
                Button1.Visible = false;
                Label1.Visible = false;
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label5.Visible = true;
            Label2.Visible = true;


            waresAskedItems = TaskUtils.GetOrderItems(warehouse, order);
            priceUnderOver = TaskUtils.UnderAskPrice(waresAskedItems, order);
            wareOutOfStock = TaskUtils.OutOfStock(priceUnderOver, order);
            waresSoldUnsold = TaskUtils.MatchAskingAmount(priceUnderOver, order);
            SellingWaresTable(Table2, order);
            SellingWaresTable(Table1, waresSoldUnsold.Item1);

            Label3.Visible = true;
            TextBox1.Visible = true;
            Button2.Visible = true;
                
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label5.Visible = true;
            Label2.Visible = true;


            waresAskedItems = TaskUtils.GetOrderItems(warehouse, order);
            priceUnderOver = TaskUtils.UnderAskPrice(waresAskedItems, order);
            wareOutOfStock = TaskUtils.OutOfStock(priceUnderOver, order);
            waresSoldUnsold = TaskUtils.MatchAskingAmount(priceUnderOver, order);
            SellingWaresTable(Table2, order);
            SellingWaresTable(Table1, waresSoldUnsold.Item1);

            Label3.Visible = true;
            TextBox1.Visible = true;
            Button2.Visible = true;

            Label4.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;

            InOut.PrintWares(order, "Užsakymas", Server.MapPath("App_Data/Result.txt"));
            InOut.PrintWares(waresSoldUnsold.Item1, "Parduodamos prekės", Server.MapPath("App_Data/Result.txt"));

            Tuple<List<Wares>,List<Wares>> waresLimitations = TaskUtils.ApplyLimitation(waresSoldUnsold.Item1, decimal.Parse(TextBox1.Text));

            SellingWaresTable(Table3, waresLimitations.Item1);

            List<Wares> allUnsold = TaskUtils.Combine3Lists(waresSoldUnsold.Item2, waresLimitations.Item2, wareOutOfStock);
            UnsoldTable(Table4, allUnsold);
            AllDataTable(Table5, warehouse);

            InOut.PrintWares(waresLimitations.Item1, "Parduodamos prekės po limitacijos", Server.MapPath("App_Data/Result.txt"));
            InOut.PrintUnsold(allUnsold, "Neparduotos prekės", Server.MapPath("App_Data/Result.txt"));
        }
    }
}   