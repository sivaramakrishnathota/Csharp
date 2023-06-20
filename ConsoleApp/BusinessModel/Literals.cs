using System;

namespace BusinessModel
{
    /// <summary>
    /// it has all the required strings.
    /// </summary>
    public static class Literals
    {
        public static string UserOption = "enter the required option 1.Register , 2.login,0.exit";
        //   public static string UserInput = "Enter user_name,password,mobile_no and emailId.";
        public static string userName = "enter user_name";
        public static string inValidUser = "enter valid user_name";
        public static string userPassword = "enter user_password";
        public static string inValidPassword = "enter valid user_password";
        public static string userMobilenumber = "enter user_mobile_number";
        public static string inValidMobileNumber = "enter valid user_mobile_number";
        public static string userEmail = "enter user_mailId";
        public static string inValidEmail = "enter valid user_mailId";
        public static string userAndPassword = "Enter user_name and password.";
        public static string inValidOption = "enter valid options";
        public static string registerCompleted = "Register Completed";
        public static string alreadyExist = "already exist";
        public static string logined = "You have Successfully Logined";
        public static string exitOptions = "if you want to logout enter 3 and to change password enter 4";
        public static string logOut = "you are logout";
        public static string newPassword = "enter user_name and new password";
        public static string changePassword = "successfuly changed password";
        public static string forLogout = "if you want to logout enter 4";
        public static string passwordCheck = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])[A-Za-z\d!@#$%^&*()_+=\[{\]};:<>|./?,-]{8,}$";
        public static string emailCheck = @"^[6-9]\d{9}$";
        public static string mobileNumberCheck = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
    }
}
