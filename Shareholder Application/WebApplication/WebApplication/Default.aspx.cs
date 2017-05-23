using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication5
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CompanyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BrokerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TransactionTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void shareAmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            doTrade(CompanyDropDownList.SelectedValue.ToString(), BrokerDropDownList.SelectedValue.ToString(), SeDropDownList.SelectedValue.ToString(), TransactionTypeDropDownList.SelectedValue.ToString(), shareAmountTextBox.Text);
            Label1.Visible = true;
        }


        public void doTrade(string companyName, string brokerName, string seName, string transactionType, string shareAmount)
        {
            string Username = User.Identity.Name;

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT * FROM Users where username ='" + Username + "'", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            string first_name = table.Rows[0]["first_name"].ToString();
            string last_name = table.Rows[0]["last_name"].ToString();
            Cn.Close();

            DataTable table1 = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com1 = new OleDbCommand(@"SELECT share_holder_id from share_holders where first_name ='" + first_name + "' and last_name = '" + last_name + "'", con);
            con.Open();
            OleDbDataReader Dr1 = Com1.ExecuteReader();
            table1.Load(Dr1);
            string share_holder_id = table1.Rows[0]["share_holder_id"].ToString();
            con.Close();

            DataTable table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT stock_ex_id from stock_exchanges where name ='" + seName + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string stock_ex_id = table2.Rows[0]["stock_ex_id"].ToString();
            con1.Close();


            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"select share_id from companies co inner join shares s on co.company_id = s.company_id where co.name = '" + companyName + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            string share_id = table3.Rows[0]["share_id"].ToString();
            con2.Close();


            string[] BrokerName = brokerName.Split(' ');
            string firstName = BrokerName[0];
            string lastName = BrokerName[1];

            DataTable table4 = new DataTable();
            OleDbConnection con3 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com4 = new OleDbCommand(@"SELECT broker_id from brokers where first_name ='" + firstName + "'and last_name ='" + lastName + "'", con3);
            con3.Open();
            OleDbDataReader Dr4 = Com4.ExecuteReader();
            table4.Load(Dr4);
            string broker_id = table4.Rows[0]["broker_id"].ToString();
            con3.Close();


            DataTable table5 = new DataTable();
            OleDbConnection con4 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com5 = new OleDbCommand(@"SELECT type_id from transaction_types where transaction_type ='" + transactionType + "'", con4);
            con4.Open();
            OleDbDataReader Dr5 = Com5.ExecuteReader();
            table5.Load(Dr5);
            string transaction_type_id = table5.Rows[0]["type_id"].ToString();
            con4.Close();

            DataTable table6 = new DataTable();
            OleDbConnection con5 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com6 = new OleDbCommand(@"select (Max(trade_id)+1) as current_trade_id from trades", con5);
            con5.Open();
            OleDbDataReader Dr6 = Com6.ExecuteReader();
            table6.Load(Dr6);
            string trade_id = table6.Rows[0]["current_trade_id"].ToString();
            con5.Close();

            DataTable table7 = new DataTable();
            OleDbConnection con6 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com7 = new OleDbCommand(@"select tb.c1 as company_name, tb.issued,tb.price, tb.time_start, tb.time_end, tb.c2 as currency, tb.symbol from (select c.name c1, p.city, p.country, sa.issued, sa.date_start, sa.date_end, sp.price, sp.time_start, sp.time_end, cu.name c2, cu.symbol FROM companies c INNER JOIN places p on c.place_id = p.place_id inner join shares s on s.company_id = c.company_id inner join shares_amount sa on sa.share_id = s.share_id inner join shares_prices sp on sp.share_id = s.share_id inner join currencies cu on cu.currency_id = s.currency_id order by sp.time_start DESC) tb where rownum < 2 and rownum >0 and tb.c1 = '" + companyName + "'", con6);
            con6.Open();
            OleDbDataReader Dr7 = Com7.ExecuteReader();
            table7.Load(Dr7);
            string price = table7.Rows[0]["price"].ToString();
            con6.Close();

            DateTime value = new DateTime(2010, 1, 18);
            value = DateTime.Today;

            double p = Convert.ToDouble(price);
            int a = Convert.ToInt32(shareAmount);
            double p_t = p * a;
            string price_total = p_t.ToString();

            DataTable table8 = new DataTable();
            OleDbConnection con7 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com8 = new OleDbCommand(@"insert into trades values ('" + trade_id + "','" + share_id + "','" + broker_id + "','" + stock_ex_id + "','21 Sep 2012','" + shareAmount + "','" + price_total + "', '" + share_holder_id + "', '" + transaction_type_id + "')", con7);
            con7.Open();
            OleDbDataReader Dr8 = Com8.ExecuteReader();
            table8.Load(Dr8);
            con7.Close();
        }


       



       

    }
}
