

//using Microsoft.Extensions.Logging;
//using ShopApp.DAL.Context;
//using ShopApp.DAL.Entities;
//using ShopApp.DAL.Exceptions;
//using ShopApp.DAL.Interfaces;
//using ShopApp.DAL.Models.Category;
//using ShopApp.DAL.Models.Supplier;

//namespace ShopApp.DAL.Daos
//{
//    public  class DaoSupplier : IDaoSupplier
//    {
//        public class DaoSupplier 
//        {
//            private readonly ShopContext _context;
//            private readonly ILogger<DaoSupplier> _logger;
//            public DaoSupplier(ShopContext context, ILogger<DaoSupplier> logger)
//            {
//                _context = context;
//                _logger = logger;
//            }
//            public void CreateSupplier(SupplierCreateOrUpdateModel supplierCreateOrUpdateModel)
//            {
//                try
//                {
//                    if (supplierCreateOrUpdateModel is null)
//                    {
//                        //Lanzar la excepcion   
//                        throw new CategoryDaoException("Debe ingresar el parametro.");


//                        Supplier supplier = new Supplier()
//                        {
//                            //

//                        };
//                    }

//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError("Ocurrio un error creando un suplidor", ex.ToString());

//                }
//            }

//            public List<GetSupplierModel> GetSupplier()
//            {
//                throw new NotImplementedException();
//            }

//            public GetSupplierModel GetSupplierById(int supplierId)
//            {
//                throw new NotImplementedException();
//            }

//            public void ModifySupplier(GetSupplierModel supplierCreateOrUpdateModel)
//            {
//                throw new NotImplementedException();
//            }

//            public void RemoveSupplier(GetSupplierModel supplierCreateOrUpdateModel)
//            {
//                throw new NotImplementedException();
//            }
//        }
//    }

//}

