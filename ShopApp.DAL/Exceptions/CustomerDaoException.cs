
namespace ShopApp.DAL.Exceptions
{
    public class CustomerDaoException : Exception
    {
        public CustomerDaoException(string message) : base(message)
        {
            //Persistir el Error o enviar notificacion
        }
    }
}
