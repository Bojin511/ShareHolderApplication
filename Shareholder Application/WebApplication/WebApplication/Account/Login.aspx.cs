using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace WebApplication5.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=";
            RequestHyperLink.NavigateUrl = "SendUserRequest.aspx?ReturnUrl=";
        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }
     
        protected void LoginButton_Click(object sender, EventArgs e)
        {

            int c = UserValidator.getUserByUsername(UserName.Text, Password.Text);
            if (c != 0)
            {
                UserLoginLogger.logSuccess(UserName.Text);
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
            }
            else
            {
                UserLoginLogger.logFailed(UserName.Text);
            }
        }
    }
}
