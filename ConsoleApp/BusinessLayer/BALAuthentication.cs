using BusinessModel;
using DataLayer;

namespace BusinessLayer
{
    internal class BALAuthentication : IBAL
    {
        /// <summary>
        /// in this method it call the registereddata method for to store the user data in list.
        /// </summary>
        /// <param name="userObj"></param>
        public void Register(User userObj)
        {
            DALFactory DALFactoryObj = new DALFactory();
            IDAL DALObj = DALFactoryObj.GetDALAuthenticationObj();
            DALObj.RegisteredData(userObj);
        }

        /// <summary>
        /// to check validinputs are not .
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool Login(User userObj)
        {
            DALFactory DALFactoryObj = new DALFactory();
            IDAL DALObj = DALFactoryObj.GetDALAuthenticationObj();
            bool isValid = DALObj.ValidLogin(userObj);
            return isValid;
        }
    }
}
