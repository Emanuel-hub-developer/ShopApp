

namespace ShopApp.DAL.Exceptions
{
    public class EmployeeDaoException : Exception
    {
        public EmployeeDaoException(string message) : base(message)
        {
            //Persistir el Error o enviar notificacion
        }
    }
}
