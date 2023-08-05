using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpAndLoginApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            BLLFactory factoryObj = new BLLFactory();
            IBLL bLLObj = factoryObj.GetBLLAuthenticationObj();
            string isAuthenticated = bLLObj.UserLogin(email, password);
            if (isAuthenticated=="true")
            {
                Response.Redirect("LogOut.aspx");
            }
            else if(isAuthenticated=="false")
            {
                Response.Write("Invalid email or password.");
            }
            else { Response.Write(bLLObj.UserLogin(email, password)); }
        }
        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForGotPassword.aspx");
        }
    }
}