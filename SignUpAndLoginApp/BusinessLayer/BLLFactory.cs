namespace BusinessLayer
{
    public class BLLFactory
    {
        public IBLL GetBLLAuthenticationObj()
        {
            IBLL  bLL_Obj = new BLLAuthentication();
            return bLL_Obj;
        }
    }
}
