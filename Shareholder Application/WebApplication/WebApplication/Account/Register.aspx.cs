using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

namespace WebApplication5.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            UserAdder.insertUser(UserName.Text, Password.Text, FirstName.Text, LastName.Text, Email.Text, DateOfBirth.Text, " ");
            Response.Redirect("Login.aspx", true);
        }

    }
}
