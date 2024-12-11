
//using Microsoft.Extensions.Logging;
//using ShopApp.DAL.Context;
//using ShopApp.DAL.Entities;
//using ShopApp.DAL.Exceptions;
//using ShopApp.DAL.Interfaces;
//using ShopApp.DAL.Models.Category;
//using ShopApp.DAL.Models.Customer;
//using ShopApp.DAL.Models.ValidatorModel;
//using System.Threading.Tasks;

//namespace ShopApp.DAL.Daos
//{
//    public class DaoCustomer : IDaoCustomer
//    {
//        private readonly ShopContext _context;
//        private readonly ILogger<DaoCustomer> _logger;
//        private readonly GenericValidator _genericValidator;

//        public DaoCustomer(ShopContext context, ILogger<DaoCustomer> logger)
//        {
//            _context = context;
//            _logger = logger;

//        }

//        public void CreateCustomer(CustomerCreateOrUpdateModel customerCreateOrUpdateModel)
//        {
//            try
//            {
//                // Validar los datos usando el validador genérico
//                _genericValidator.Validate(customerCreateOrUpdateModel); // Validación general

//                // Validaciones específicas para los campos
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.companyname, 40);  
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.contactname, 30);  
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.contacttitle, 30); 
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.address, 60); 
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.city,15);  
//                _genericValidator.ValidateEmail(customerCreateOrUpdateModel.email);  
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.region, 15);  
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.postalcode, 10); 
//                _genericValidator.ValidateStringWithoutDigits(customerCreateOrUpdateModel.country, 15);
//                _genericValidator.ValidateStringWithNumbers(customerCreateOrUpdateModel.phone, 24);
//                _genericValidator.ValidateStringWithNumbers(customerCreateOrUpdateModel.fax, 24);

//                // Si las validaciones pasan, se guarda en la base de datos
//                Customer customer = new Customer()
//                {
//                    custid = customerCreateOrUpdateModel.customerId,
//                    modify_user = customerCreateOrUpdateModel.UserId,
//                    ChangeDate = customerCreateOrUpdateModel.ChangeDate,
//                    description = customerCreateOrUpdateModel.description
//                };

//                _context.Categories.Add(category);
//                _context.SaveChanges();
//            }
//            catch (ArgumentException ex)
//            {
//                // Manejo de excepciones de validación
//                _logger.LogError($"Error al crear categoría: {ex.Message}", ex);
//                throw new CategoryDaoException(ex.Message); // Lanzar una excepción personalizada con mensaje detallado
//            }
//            catch (Exception ex)
//            {
//                // Manejo de otras excepciones
//                _logger.LogError("Error inesperado al crear una categoría", ex.ToString());
//                throw new CategoryDaoException("Error inesperado al crear una categoría.");
//            }
//        }

//        public GetCustomerModel GetGetCustomerById(int customerId)
//        {

//            try
//            {
//                if (customerId <= 0)
//                {
//                    throw new ArgumentException("El ID de la categoría no puede ser menor o igual a cero.");
//                }

              
//                Customer? customer = _context.Customers.Find(customerId);
//                if (customer == null)
//                {
//                    throw new ArgumentException("Categoría no encontrada.");
//                }

               
//                return new GetCustomerModel
//                {
//                    customerId = customer.custid,
//                    companyname = customer.companyname,
//                    contacttitle = customer.contacttitle,
//                    modify_user = customer.modify_user,
//                    ChangeDate = customer.modify_date,
//                     = category.description
//                };
//            }
//            catch (ArgumentException ex)
//            {
//                _logger.LogError($"Error al obtener la categoría con ID {customerId}: {ex.Message}", ex);
//                throw new CategoryDaoException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Error inesperado al obtener la categoría", ex.ToString());
//                throw new CategoryDaoException("Error inesperado al obtener la categoría.");
//            }
//        }


//        public List<GetCustomerModel> GetCustomers()
//        {
//            List<GetCustomerModel> categoriesList = new List<GetCustomerModel>();

//            try

//            {
//                var query = (from customer in _context.Customers
//                             where customer.deleted == false
//                             select new GetCategoryModel()
//                             {
//                                customerId = customer.custid,
//                                 companyname = customer.companyname,
//                                 companytittle = category.description,
//                                 creation_date = category.creation_date
//                             }).ToList();


//            }
//            catch (ArgumentException ex) { _logger.LogError("Error inesperado al obtener customer", ex.ToString()); }

//            return categoriesList;
//        }

//        public void ModifyCustomers(CustomerCreateOrUpdateModel customerCreateOrUpdateModel)
//        {
//            try
//            {
                
//                    throw new ArgumentException("Customer no encontrado.");
               

               
//            }
//            catch (ArgumentException ex)
//            {
//                _logger.LogError($"Error al modificar customer: {ex.Message}", ex);
//                throw new CategoryDaoException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Error inesperado al modificar customer", ex.ToString());
//                throw new CategoryDaoException("Error inesperado al modificar customer.");
//            }
//        }

//        public void RemoveCustomers(CategoryCreateOrUpdateModel categoryCreateOrUpdateModel)
//        {
//            try
//            {
               
//                    throw new ArgumentException("Por el momento no se pueden remover los customers");
                
//            }
//            catch (ArgumentException ex)
//            {
//                _logger.LogError($"Error al eliminar customer: {ex.Message}", ex);
//                throw new CategoryDaoException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Error inesperado al eliminar un customer", ex.ToString());
//                throw new CategoryDaoException("Error inesperado al eliminar customer.");
//            }
//        }
//    }
//}
