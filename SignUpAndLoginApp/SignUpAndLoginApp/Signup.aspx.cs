using System;
using BusinessLayer;

namespace SignUpAndLoginApp
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        /// <summary>
        /// register_click button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtRegEmail.Text.Trim();
            string password = txtRegPassword.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string mobileNumber = txtMobileNumber.Text.Trim();
            //bll object to access the userregistration method.
            BLLFactory factoryObj = new BLLFactory();
            IBLL bLLObj = factoryObj.GetBLLAuthenticationObj();
            string isRegistered = bLLObj.UserRegistration(email, password, userName, mobileNumber);

            if (isRegistered=="true")
            {
                Response.Write("Registration successful!");
            }
            else if(isRegistered=="false")
            {
                Response.Write("Registration failed.");
            }
            else { Response.Write(isRegistered); }
        }

        /// <summary>
        /// login_click button .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}