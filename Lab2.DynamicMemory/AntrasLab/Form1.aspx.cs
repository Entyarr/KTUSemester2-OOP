using AntrasLab.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntrasLab
{
    public partial class Form1 : System.Web.UI.Page
    {
        private const string inputFileA = @"App_Data/U9a.txt";
        private const string inputFileB = @"App_Data/U9b.txt";
        private const string outputFile = @"App_Data/Rezultatai.txt";

        private AgentList Agents;
        private CustomerList Customers;


        private CustomersByAgentList AgentMasterList;
        private CustomersByAgentList OverAvgMasterList;
        private CustomersByAgentList AddedCustomersAgents;
        protected void Page_Load(object sender, EventArgs e)
        {
            Agents = InOut.ReadAgents(Server.MapPath(inputFileB));
            Customers = InOut.ReadCustomers(Server.MapPath(inputFileA));

            CustomersTable(Table2, Customers);
            AgentsTable(Table3, Agents);

            InOut.CreateOutFile(Server.MapPath(outputFile));
            InOut.PrintCustomers(Customers, Server.MapPath(outputFile), "Prenumeratoriai");
            InOut.PrintAgents(Agents, Server.MapPath(outputFile), "Agentai");

            Customers.Sort();
            AgentMasterList = TaskUtils.Reformat(Agents, Customers);

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int month = int.Parse(TextBox1.Text);

            TaskUtils.CustomersInGivenMonth(AgentMasterList, month);
            Customers.Sort();
            MonthTable(Table4, AgentMasterList);
            InOut.PrintMasterList(AgentMasterList, Server.MapPath(outputFile), "Agentai, kurie turi prenumeratorių duotam mėnesiui:");

            int monthlyMagCount = TaskUtils.MagazineAmount(AgentMasterList);
            Label8.Text = monthlyMagCount.ToString();
            InOut.PrintMagazineText(Server.MapPath(outputFile), "Bendras leidinių kiekis:", monthlyMagCount);

            TaskUtils.AgentMagazineAmount(AgentMasterList);
            OverAvgMasterList = TaskUtils.AboveAverage(AgentMasterList, monthlyMagCount);
            MonthTable(Table5, OverAvgMasterList);
            InOut.PrintMasterList(OverAvgMasterList, Server.MapPath(outputFile), "Agentai, kurie turi prenumeratorių duotam mėnesiui:");

            AddedCustomersAgents = TaskUtils.ReplaceCustomers(AgentMasterList, OverAvgMasterList, monthlyMagCount);
            MonthTable(Table6, AddedCustomersAgents);
            InOut.PrintMasterList(AddedCustomersAgents, Server.MapPath(outputFile), "Agentai, kuriem buvo perduoti prenumeratoriai:");

        }
    }
}