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
    public partial class Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = User.Identity.Name;
            getStockExchangeList(Username);
            getCompanyShares(Username);
            getRegisteredBrokerList(Username);

        }




        public DataTable getStockExchangeList(string Username)
        {
            //string Username = User.Identity.Name;

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT * FROM Users where username ='" + Username + "'", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            string first_name = table.Rows[0]["first_name"].ToString();
            string last_name = table.Rows[0]["last_name"].ToString();
            Cn.Close();

            DataTable table1;
            table1 = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com1 = new OleDbCommand(@"select se.name, se.symbol, p.city, p.country from share_holders sh inner join share_holder_stock_ex shse on shse.share_holder_id = sh.share_holder_id inner join stock_exchanges se on se.stock_ex_id = shse.stock_ex_id inner join places p on p.place_id = se.place_id where sh.first_name = '" + first_name + "' and sh.last_name = '" + last_name + "'", con);
            con.Open();
            OleDbDataReader Dr1 = Com1.ExecuteReader();
            table1.Load(Dr1);
            GridView1.DataSource = table1;
            DataBind();
            con.Close();
            return table1;
        }


        public DataTable getCompanyShares(string Username)
        {
            //string Username = User.Identity.Name;

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT * FROM Users where username ='" + Username + "'", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            string first_name = table.Rows[0]["first_name"].ToString();
            string last_name = table.Rows[0]["last_name"].ToString();
            Cn.Close();

            DataTable table1;
            table1 = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com1 = new OleDbCommand(@"SELECT shs.amount, c.name FROM share_holders sh inner join share_holder_shares shs on sh.share_holder_id = shs.share_holder_id inner join shares s on s.share_id = shs.share_id inner join companies c on c.company_id = s.company_id where sh.first_name ='" + first_name + "'and sh.last_name ='" + last_name + "'", con);
            con.Open();
            OleDbDataReader Dr1 = Com1.ExecuteReader();
            table1.Load(Dr1);
            GridView2.DataSource = table1;
            DataBind();
            con.Close();
            return table1;

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            registerStockExchange(registerDropDownList.SelectedValue.ToString());

        }

        public void registerStockExchange(string name)
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
            OleDbCommand Com1 = new OleDbCommand(@"SELECT share_holder_id from share_holders where first_name ='" + first_name + "' and last_name = '"+ last_name + "'", con);
            con.Open();
            OleDbDataReader Dr1 = Com1.ExecuteReader();
            table1.Load(Dr1);
            string share_holder_id = table1.Rows[0]["share_holder_id"].ToString();
            con.Close();

            DataTable table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT stock_ex_id from stock_exchanges where name ='" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string stock_ex_id = table2.Rows[0]["stock_ex_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"insert into share_holder_stock_ex (share_holder_id,stock_ex_id) select '" + share_holder_id + "','" + stock_ex_id + "' from dual where not EXISTS (select * from share_holder_stock_ex where share_holder_id = '" + share_holder_id + "' and stock_ex_id = '" + stock_ex_id + "')", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();



        }



        protected void registerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void brokerRegisterButton_Click(object sender, EventArgs e)
        {
            registerBroker(brokersDropDownList.SelectedValue.ToString());
        }

        public void registerBroker(string name)
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

            string[] brokerName = name.Split(' ');
            string firstName = brokerName[0];
            string lastName = brokerName[1];

            DataTable table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT broker_id from brokers where first_name ='" + firstName + "'and last_name ='" + lastName + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string broker_id = table2.Rows[0]["broker_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"insert into share_holder_broker (share_holder_id,broker_id) select '" + share_holder_id + "','" + broker_id + "' from dual where not EXISTS (select * from share_holder_broker where share_holder_id = '" + share_holder_id + "' and broker_id = '" + broker_id + "')", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }

        protected void brokersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public DataTable getRegisteredBrokerList(string Username)
        {
            //string Username = User.Identity.Name;

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT * FROM Users where username ='" + Username + "'", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            string first_name = table.Rows[0]["first_name"].ToString();
            string last_name = table.Rows[0]["last_name"].ToString();
            Cn.Close();

            DataTable table1;
            table1 = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com1 = new OleDbCommand(@"select b.first_name, b.last_name from share_holders sh inner join share_holder_broker shb on shb.share_holder_id = sh.share_holder_id inner join brokers b on b.broker_id = shb.broker_id where sh.first_name = '" + first_name + "' and sh.last_name = '" + last_name + "'", con);
            con.Open();
            OleDbDataReader Dr1 = Com1.ExecuteReader();
            table1.Load(Dr1);
            GridView3.DataSource = table1;
            DataBind();
            con.Close();
            return table1;
        }

        protected void seUnregisterButton_Click(object sender, EventArgs e)
        {
            unregisterStockExchange(registerDropDownList.SelectedValue.ToString());
        }


        public void unregisterStockExchange(string name)
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
            OleDbCommand Com2 = new OleDbCommand(@"SELECT stock_ex_id from stock_exchanges where name ='" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string stock_ex_id = table2.Rows[0]["stock_ex_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"delete from share_holder_stock_ex where share_holder_id = '" + share_holder_id + "' and stock_ex_id = '" + stock_ex_id + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();



        }

        protected void brokerUnregisterButton_Click(object sender, EventArgs e)
        {
            unregisterBroker(brokersDropDownList.SelectedValue.ToString());
        }

        public void unregisterBroker(string name)
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

            string[] brokerName = name.Split(' ');
            string firstName = brokerName[0];
            string lastName = brokerName[1];

            DataTable table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT broker_id from brokers where first_name ='" + firstName + "'and last_name ='" + lastName + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string broker_id = table2.Rows[0]["broker_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"delete from share_holder_broker where share_holder_id = '" + share_holder_id + "' and broker_id = '" + broker_id + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }

        protected void StockExDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView4.DataSource = getBrokersList();
            DataBind();
        }

        public DataTable getBrokersList()
        {
            string stockExName;
            stockExName = StockExDropDownList1.SelectedValue.ToString();

            DataTable table;
            table = new DataTable();
            OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com = new OleDbCommand("select (b.first_name || ' ' || b.last_name) as broker_name from brokers b inner join broker_stock_ex bse on b.broker_id = bse.broker_id inner join stock_exchanges se on se.stock_ex_id = bse.stock_ex_id where se.name = '" + stockExName + "'", con);
            con.Open();
            OleDbDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            con.Close();
            return table;

        }
    }
}

