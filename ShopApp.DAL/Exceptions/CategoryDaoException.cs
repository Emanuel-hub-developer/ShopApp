

namespace ShopApp.DAL.Exceptions
{
    public  class CategoryDaoException : Exception
    {
        public CategoryDaoException(string message) : base (message)
        { 
            //Persistir el Error o enviar notificacion
        }
    }
}
