using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

namespace WebApplication5.Account
{
    public partial class SendUserRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            IssueAdder.addRequest(UserName1.Text, Issue.Text, Date1.Text, Description.Text, StatusDropDownList.Text);
            Response.Redirect("Login.aspx", true);
        }

        protected void Description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}