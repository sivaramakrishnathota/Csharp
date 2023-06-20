namespace BusinessLayer
{
    public class BALFactory
    {
        /// <summary>
        /// Her we creating the object for BALAuthentication with the reference of interface.
        /// </summary>
        /// <returns></returns>S
        public IBAL GetBALAuthenticationObj()
        {
            IBAL IBALObj = new BALAuthentication();
            return IBALObj;
        }

        /// <summary>
        /// Her we creating the object for BALValidation with the reference of interface.
        /// </summary>
        /// <returns></returns>
        public IValidation GetBALValidationObj()
        {
            IValidation ValidationObj = new BALValidations();
            return ValidationObj;
        }
    }
}
