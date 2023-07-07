using BusinessModel;
using DataLayer;
using DataModel;

namespace BusinessLayer
{
    internal class BALAuthentication : IBAL
    {

        /// <summary>
        /// this method gets the data from datalyer and it sends to the presentation layer.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetData(string userName)
        {
            DALFactory dalFactoryObj = new DALFactory();
            IDAL idalobj = dalFactoryObj.GetDALAuthenticationObj();
            User user = idalobj.GetData(userName);
            return user;
        }
        /// <summary>
        /// in this method it call the registereddata method for to store the user data in list.
        /// </summary>
        /// <param name="userObj"></param>
        public void Register(User userObj)
        {
            DALFactory dalFactoryObj = new DALFactory();
            IDAL dalObj = dalFactoryObj.GetDALAuthenticationObj();
            dalObj.RegisteredData(userObj);
        }

        /// <summary>
        /// to check validinputs are not .
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool Login(User userObj)
        {
            DALFactory dalFactoryObj = new DALFactory();
            IDAL dalObj = dalFactoryObj.GetDALAuthenticationObj();
            bool isValid = dalObj.ValidLogin(userObj);
            return isValid;
        }
    }
}
