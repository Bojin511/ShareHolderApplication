using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace WebApplication5
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Load_GridData();

        }

        protected void BrokersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string brokerName;
            brokerName = BrokersDropDownList.SelectedValue.ToString();

            string[] name = brokerName.Split(' ');
            string firstName = name[0];
            string lastName = name[1];

            DataTable table = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou;Password=BZA278sG;Unicode=True");
            OleDbCommand Com = new OleDbCommand("select distinct (b.first_name || ' '|| b.last_name) as broker_name, se.name as stock_exchange_name, se.symbol, p.city, p.country from brokers b inner join broker_stock_ex bse on bse.broker_id = b.broker_id inner join stock_exchanges se on se.stock_ex_id = bse.stock_ex_id inner join places p on p.place_id = se.place_id where b.first_name = '" + firstName + "'  and b.last_name = '" + lastName + "' ", con);
            con.Open();
            OleDbDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);

            GridView1.DataSource = table;
            DataBind();
            con.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = getcompnay();
            Chart1.DataSource = getcompnay();
            //DataBind();
        }

        public DataTable getcompnay()
        {
            string companyName;
            companyName = CompaniesDropDownList.SelectedValue.ToString();

            DataTable table = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou;Password=BZA278sG;Unicode=True");
            //OleDbCommand Com = new OleDbCommand("SELECT c.name, p.city, p.country, sa.issued, sa.date_start, sa.date_end, sp.price, sp.time_start, sp.time_end, cu.name, cu.symbol FROM companies c INNER JOIN places p on c.place_id = p.place_id inner join shares s on s.company_id = c.company_id inner join shares_amount sa on sa.share_id = s.share_id inner join shares_prices sp on sp.share_id = s.share_id inner join currencies cu on cu.currency_id = s.currency_id where c.name = '" + companyName + "' order by sp.time_start DESC", con);
            OleDbCommand Com = new OleDbCommand("select c.name c1, p.city, p.country, sa.issued, sa.date_start, sa.date_end, sp.price, sp.time_start, sp.time_end, cu.name c2, cu.symbol FROM companies c INNER JOIN places p on c.place_id = p.place_id inner join shares s on s.company_id = c.company_id inner join shares_amount sa on sa.share_id = s.share_id inner join shares_prices sp on sp.share_id = s.share_id inner join currencies cu on cu.currency_id = s.currency_id where c.name = '" + companyName + "'  order by sp.time_start DESC ", con);
            con.Open();
            OleDbDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);

            //GridView1.DataSource = table;
            //Chart1.DataSource = table;
            DataBind();
            con.Close();
            return table;
        }


            public DataTable Load_GridData()
            {
                DataTable table = new DataTable();
                OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou;Password=BZA278sG;Unicode=True");
                OleDbCommand Com = new OleDbCommand("select tb.c1 as company_name, tb.issued,tb.price, tb.time_start, tb.time_end, tb.c2 as currency, tb.symbol from (select c.name c1, p.city, p.country, sa.issued, sa.date_start, sa.date_end, sp.price, sp.time_start, sp.time_end, cu.name c2, cu.symbol FROM companies c INNER JOIN places p on c.place_id = p.place_id inner join shares s on s.company_id = c.company_id inner join shares_amount sa on sa.share_id = s.share_id inner join shares_prices sp on sp.share_id = s.share_id inner join currencies cu on cu.currency_id = s.currency_id order by sp.time_start DESC) tb where rownum < 9 and rownum >0", con);
                con.Open();
                OleDbDataReader Dr = Com.ExecuteReader();
                table.Load(Dr);
                GridView3.DataSource = table;
                DataBind();
                con.Close();
                return table;
            }


            protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = getcompnay();
                Chart1.DataSource = getcompnay();

            }

            protected void Chart1_Load(object sender, EventArgs e)
            {

            }






    }
}

