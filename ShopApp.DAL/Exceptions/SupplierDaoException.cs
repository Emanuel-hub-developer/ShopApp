

namespace ShopApp.DAL.Exceptions
{
    public class SupplierDaoException : Exception
    {
        public SupplierDaoException(string message) : base(message)
        {
            //Persistir el Error o enviar notificacion
        }
    }
}
