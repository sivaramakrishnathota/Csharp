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
            IDAL IDALobj =  new DALAuthentication();
            return IDALobj;
        }
    }
}
