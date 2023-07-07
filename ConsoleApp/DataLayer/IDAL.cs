﻿using BusinessModel;
using DataModel;
namespace DataLayer
{
    public interface IDAL
    {
        public void RegisteredData(User userObj);
        public bool ValidLogin(User userObj);
        public bool IsValidRegistration(User userObj);
        public bool ChangePassword(User userObj, string newPassword);
        public User GetData(string userName);
    }
}
