using AntrasLab.Methods;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntrasLab
{
    public partial class Form1 : System.Web.UI.Page
    {
        private const string outputFile = @"App_Data/Rezultatai.txt";

        private LinkedList<Agent> Agents;
        private LinkedList<Customer> Customers;
        


        private LinkedList<CustomersByAgent> AgentMasterList;
        private LinkedList<CustomersByAgent> OverAvgMasterList;
        private LinkedList<CustomersByAgent> AddedCustomersAgents;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Customers = InOut.ReadCustomers(FileUpload1.FileContent);
            Agents = InOut.ReadAgents(FileUpload2.FileContent);

            CustomersTable(Table2, Customers);
            AgentsTable(Table3, Agents);

            InOut.CreateOutFile(Server.MapPath(outputFile));
            InOut.PrintCustomers(Customers, Server.MapPath(outputFile), "Prenumeratoriai");
            InOut.PrintAgents(Agents, Server.MapPath(outputFile), "Agentai");

            AgentMasterList = TaskUtils.Reformat(Agents, Customers);
            TaskUtils.SortMasterList(AgentMasterList);


            int month = int.Parse(TextBox1.Text);
            InOut.MonthInQuestion(Server.MapPath(outputFile), month);

            TaskUtils.CustomersInGivenMonth(AgentMasterList, month);
            Customers.Sort();
            MonthTable(Table4, AgentMasterList);
            InOut.PrintMasterList(AgentMasterList, Server.MapPath(outputFile), "Agentai, kurie turi prenumeratorių duotam mėnesiui:");


            int monthlyMagCount = TaskUtils.MagazineAmount(AgentMasterList);
            Label8.Text = monthlyMagCount.ToString();
            InOut.PrintMagazineText(Server.MapPath(outputFile), "Bendras leidinių kiekis:", monthlyMagCount);

            TaskUtils.AgentMagazineAmount(AgentMasterList);
            OverAvgMasterList = TaskUtils.AboveAverage(AgentMasterList, monthlyMagCount);
            TaskUtils.SortMasterList(OverAvgMasterList);
            MonthTable(Table5, OverAvgMasterList);
            InOut.PrintMasterList(OverAvgMasterList, Server.MapPath(outputFile), "Agentai, kurie turi prenumeratorių duotam mėnesiui:");

            
            AddedCustomersAgents = TaskUtils.ReplaceCustomers(AgentMasterList, OverAvgMasterList, monthlyMagCount);
            TaskUtils.SortMasterList(AgentMasterList);
            MonthTable(Table6, AddedCustomersAgents);
            InOut.PrintMasterList(AddedCustomersAgents, Server.MapPath(outputFile), "Agentai, kuriem buvo perduoti prenumeratoriai:");

        }
    }
}