

//using Microsoft.Extensions.Logging;
//using ShopApp.DAL.Context;
//using ShopApp.DAL.Entities;
//using ShopApp.DAL.Exceptions;
//using ShopApp.DAL.Interfaces;
//using ShopApp.DAL.Models.Employee;

//namespace ShopApp.DAL.Daos
//{
//    public class DaoEmployee : IDaoEmployeeDb
//    {
//        private readonly ShopContext _context;
//        private readonly ILogger<DaoEmployee> _logger;
//        public DaoEmployee(ShopContext context, ILogger<DaoEmployee> logger)
//        {
//            _context = context;
//            _logger = logger;
//        }
//        public void CreateEmployee(EmployeeCreateOrUpdateModel employeeCreateOrUpdateModel)
//        {
//            try
//            {
//                if (employeeCreateOrUpdateModel is null)
//                {
//                    //Lanzar la excepcion   
//                    throw new CategoryDaoException("Debe ingresar el parametro.");


//                    Category category = new Category()
//                    {
//                        //

//                    };
//                }

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Ocurrio un error creando un empleado", ex.ToString());

//            }
//        }

//        public List<GetEmployeeModel> GetEmployee()
//        {
//            throw new NotImplementedException();
//        }

//        public GetEmployeeModel GetEmployeeById(int employeeId)
//        {
//            throw new NotImplementedException();
//        }

//        public void ModifyEmployee(EmployeeCreateOrUpdateModel employeeCreateOrUpdateModel)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveEmployee(EmployeeCreateOrUpdateModel employeeCreateOrUpdateModel)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
