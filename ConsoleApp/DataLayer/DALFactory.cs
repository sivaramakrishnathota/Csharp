namespace DataLayer
{
    public class DALFactory
    {
        /// <summary>
        /// Her we creating the object for DALAuthentication with the reference of interface.
        /// </summary>
        /// <returns></returns>
        public IDAL GetDALAuthenticationObj()
        {
            IDAL idalObj = new DALAuthentication();
            return idalObj;
        }
    }
}
