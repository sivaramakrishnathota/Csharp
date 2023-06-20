﻿using BusinessModel;

namespace DataLayer
{
    /// <summary>
    /// it implements the IDAL methods.
    /// </summary>
    internal class DALAuthentication : IDAL
    {
        /// <summary>
        /// in this function has the four parameters of registered details and data stored in storage list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public void RegisteredData(User objUser)
        {
            DataSource.storage.Add(new User { userName = objUser.userName, userPassword = objUser.userPassword, userMobilenumber = objUser.userMobilenumber, userEmail = objUser.userEmail });
        }

        /// <summary>
        /// in this method it check login data is in storage list or not.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidLogin(User objUser)
        {
            User obj = DataSource.storage.Find(obj => obj.userName == objUser.userName);
            if (obj != null)
            {
                if ((obj.userName == objUser.userName) && (obj.userPassword == objUser.userPassword))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// it is to check the user_name is already exist or not.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsValidRegistration(User objUser)
        {
            User obj = DataSource.storage.Find(obj => obj.userName == objUser.userName);
            if (obj != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// it is to changing the password.
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="new_password"></param>
        /// <returns></returns>
        public bool ChangePassword(User objUser, String newPassword)
        {

            User obj = DataSource.storage.Find(obj => obj.userName == objUser.userName);
            if (obj != null)
            {
                if (obj.userName == objUser.userName)
                {
                    obj.userPassword = newPassword;
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}