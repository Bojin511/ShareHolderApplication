using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.Profile;

namespace WebApplication5
{
    public partial class UserPreference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getFavouriteSharesList();
            getWatchedSharesList();
            getFavouriteBrokersList();

            //if (!Page.IsPostBack)
            //{
            //    DropDownList2.Items.FindByValue(Profile.MyTheme).Selected = true;


            //}
        }


        protected void addToFavouriteListButton_Click(object sender, EventArgs e)
        {
            addSharesToFavouriteList(FavouriteListTextBox.Text.ToString());
        }



        public void addSharesToFavouriteList(string name)
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
            OleDbCommand Com2 = new OleDbCommand(@"select s.share_id from companies c inner join shares s on c.company_id = s.company_id where c.name = '" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string share_id = table2.Rows[0]["share_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"insert into share_holder_favourite_list (share_holder_id,share_id) select '" + share_holder_id + "','" + share_id + "' from dual where not EXISTS (select * from share_holder_favourite_list where share_holder_id = '" + share_holder_id + "' and share_id = '" + share_id + "')", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }


        public DataTable getFavouriteSharesList()
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


            DataTable table2;
            table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT c.name as Company_name FROM SHARE_HOLDER_FAVOURITE_LIST shfl inner join shares s on s.share_id = shfl.share_id inner join companies c on c.company_id = s.company_id where share_holder_id = '" + share_holder_id + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            GridView1.DataSource = table2;
            DataBind();
            con1.Close();
            return table2;
        }




        protected void addToWatchListButton_Click1(object sender, EventArgs e)
        {
            addSharesToWatchedList(WatchListTextBox.Text.ToString());
        }



        public void addSharesToWatchedList(string name)
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
            OleDbCommand Com2 = new OleDbCommand(@"select s.share_id from companies c inner join shares s on c.company_id = s.company_id where c.name = '" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string share_id = table2.Rows[0]["share_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"insert into share_holder_watch_list (share_holder_id,share_id) select '" + share_holder_id + "','" + share_id + "' from dual where not EXISTS (select * from share_holder_watch_list where share_holder_id = '" + share_holder_id + "' and share_id = '" + share_id + "')", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }



        public DataTable getWatchedSharesList()
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


            DataTable table2;
            table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT c.name as Company_name FROM SHARE_HOLDER_WATCH_LIST shfl inner join shares s on s.share_id = shfl.share_id inner join companies c on c.company_id = s.company_id where share_holder_id = '" + share_holder_id + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            GridView2.DataSource = table2;
            DataBind();
            con1.Close();
            return table2;
        }




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void addToFavouriteBrokerButton_Click(object sender, EventArgs e)
        {
            addBrokerToFavouriteList(DropDownList1.SelectedValue.ToString());
        }

        public void addBrokerToFavouriteList(string name)
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
            OleDbCommand Com3 = new OleDbCommand(@"insert into share_holder_favourite_broker (share_holder_id,broker_id) select '" + share_holder_id + "','" + broker_id + "' from dual where not EXISTS (select * from share_holder_favourite_broker where share_holder_id = '" + share_holder_id + "' and broker_id = '" + broker_id + "')", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();

        }



        public DataTable getFavouriteBrokersList()
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

            DataTable table2;
            table2 = new DataTable();
            OleDbConnection con1 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com2 = new OleDbCommand(@"SELECT b.first_name || ' ' || b.last_name as broker_name FROM SHARE_HOLDER_FAVOURITE_BROKER shfb inner join brokers b on shfb.broker_id = b.broker_id where share_holder_id = '" + share_holder_id + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            GridView3.DataSource = table2;
            DataBind();
            con1.Close();
            return table2;

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }


        protected void deleteFromFavouriteListButton_Click(object sender, EventArgs e)
        {
            deleteSharesfromFavouriteList(FavouriteListTextBox.Text.ToString());
        }



        public void deleteSharesfromFavouriteList(string name)
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
            OleDbCommand Com2 = new OleDbCommand(@"select s.share_id from companies c inner join shares s on c.company_id = s.company_id where c.name = '" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string share_id = table2.Rows[0]["share_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"delete from share_holder_favourite_list where share_holder_id = '" + share_holder_id + "' and share_id = '" + share_id + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();

        }

        protected void FavouriteListTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void deleteFromWatchListButton_Click(object sender, EventArgs e)
        {
            deleteSharesFromWatchedList(WatchListTextBox.Text.ToString());
        }



        public void deleteSharesFromWatchedList(string name)
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
            OleDbCommand Com2 = new OleDbCommand(@"select s.share_id from companies c inner join shares s on c.company_id = s.company_id where c.name = '" + name + "'", con1);
            con1.Open();
            OleDbDataReader Dr2 = Com2.ExecuteReader();
            table2.Load(Dr2);
            string share_id = table2.Rows[0]["share_id"].ToString();
            con1.Close();

            DataTable table3 = new DataTable();
            OleDbConnection con2 = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou; Password=BZA278sG; Unicode=True");
            OleDbCommand Com3 = new OleDbCommand(@"delete from share_holder_watch_list where share_holder_id = '" + share_holder_id + "' and share_id = '" + share_id + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }

        protected void WatchListTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void deleteFromFavouriteBrokerButton_Click(object sender, EventArgs e)
        {
            deleteBrokerFromFavouriteList(DropDownList1.SelectedValue.ToString());
        }

        public void deleteBrokerFromFavouriteList(string name)
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
            OleDbCommand Com3 = new OleDbCommand(@"delete from share_holder_favourite_broker where share_holder_id = '" + share_holder_id + "' and broker_id = '" + broker_id + "'", con2);
            con2.Open();
            OleDbDataReader Dr3 = Com3.ExecuteReader();
            table3.Load(Dr3);
            con2.Close();
        }



    }
}




 


       








        
