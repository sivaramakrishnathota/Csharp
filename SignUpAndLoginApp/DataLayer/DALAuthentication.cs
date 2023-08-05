using System;
using System.Data;
using System.Data.SqlClient;
using BusinessModel;
using System.Configuration;

namespace DataLayer
{
    public class DALAuthentication:IDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        /// <summary>
        /// this method is check the user details . if not exists then details will be saved.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public string IsValidRegister(string email, string password, string username, string mobileNumber)
        {
            try
            {
                bool result = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var selectQuery = "SELECT PasswordHash,Email FROM UserData where Email=@Email";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {

                        result = selectQuery.Contains(email);
                    }
                    connection.Close();
                }
                if (result == true) { return "true"; }
                else { return "false"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// this method will checks the user email_id and password.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string IsValidLogin(Users userObj)
        {
            string encodedPassword = EncodePasswordToBase64(userObj.Password);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select Email,PasswordHash from UserData where Email=@Email", connection);
            command.Parameters.AddWithValue("Email", userObj.Email);
            command.Parameters.AddWithValue("PasswordHash", encodedPassword);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataadapter);
            DataTable datatable = new DataTable("users");
            dataadapter.Fill(datatable);
            try
            {
                DataRow datarow = datatable.Rows[0];
                if (datarow["Email"].ToString() == userObj.Email && datarow["PasswordHash"].ToString() == encodedPassword)
                {
                    return "true"; //Login successful
                }
                return "false"; //Login Failed
            }
            catch (Exception ex)
            {
                return ex.Message; //login Failed
            }
        }

        /// <summary>
        /// this method will have the insert query ,it will called when register_check method gets false.this method called in BLL in UserRegistration method.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool InsertUser(Users userObj)
        {
            string encodedPassword = EncodePasswordToBase64(userObj.Password);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO UserData (Email, PasswordHash,UserName,MobileNumber) VALUES (@Email, @PasswordHash,@Username,@MobileNumber)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userObj.Email);
                        command.Parameters.AddWithValue("@PasswordHash", encodedPassword);
                        command.Parameters.AddWithValue("Username", userObj.UserName);
                        command.Parameters.AddWithValue("MobileNumber", userObj.MobileNumber);

                        command.ExecuteNonQuery();
                        return true;
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public string ToChangePassword(string email, string password, string username)
        {
            bool result = false;
            string newpassword = EncodePasswordToBase64(password);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select UserName,Email,PasswordHash from UserData where Email=@Email", connection))
                    {
                        //adapter.SelectCommand.Parameters.AddWithValue("UserName", username);
                        adapter.SelectCommand.Parameters.AddWithValue("@Email", email);
                        SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count == 1)
                        {
                            DataRow dr = dt.Rows[0];
                            dr["PasswordHash"] = newpassword;
                            adapter.Update(dt);
                            result=true;
                        }
                    }
                    connection.Close();
                }
                if( result == true ) { return "true"; }
                else { return "false"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }
}
