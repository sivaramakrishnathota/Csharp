namespace DataLayer
{
    public class DALFactory
    {
        public IDAL GetDALAuthenticationObj()
        {
            IDAL dALObj= new DALAuthentication();
            return dALObj;
        }
    }
}
