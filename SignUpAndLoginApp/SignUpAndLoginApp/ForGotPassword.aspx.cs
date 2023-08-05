using BusinessLayer;
using System;

namespace SignUpAndLoginApp
{
    public partial class ForGotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {  }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email=txtEmail.Text;
            string userName=txtUserName.Text;
            string newPassword=txtNewPassword.Text;

            BLLFactory factory_Obj=new BLLFactory();
            IBLL bLLObj=factory_Obj.GetBLLAuthenticationObj();
            if (bLLObj.ChangePassword(email, userName, newPassword)=="true")
            {
                Response.Write("successful changed password");
            }
            else if(bLLObj.ChangePassword(email, userName, newPassword)=="false")
            {
                Response.Write("password not changed");
                Response.Redirect("Signup.aspx");
            }
            else { Response.Write(bLLObj.ChangePassword(email, userName, newPassword)); }
        }
    }
}