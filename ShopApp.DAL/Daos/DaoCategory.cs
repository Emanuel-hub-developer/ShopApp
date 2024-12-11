


using Microsoft.Extensions.Logging;
using ShopApp.DAL.Context;
using ShopApp.DAL.Entities;
using ShopApp.DAL.Exceptions;
using ShopApp.DAL.Interfaces;
using ShopApp.DAL.Models.Category;
using ShopApp.DAL.Models.ValidatorModel;

namespace ShopApp.DAL.Daos
{
    public class DaoCategory : IDaoCategory
    {
        private readonly ShopContext _context;
        private readonly ILogger<DaoCategory> _logger;
        private readonly GenericValidator _genericValidator;

        public DaoCategory(ShopContext context, ILogger<DaoCategory> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        public void CreateCategory(CategoryCreateOrUpdateModel categoryCreateOrUpdateModel)
        {
            try
            {
                //Validar los datos usando el validador genérico
                _genericValidator.Validate(categoryCreateOrUpdateModel);
             

                ////Validaciones específicas para los campos
                _genericValidator.ValidateStringWithoutDigits(categoryCreateOrUpdateModel.categoryname, 15);  // Límite de longitud de categoryname
                _genericValidator.ValidateNonNegativeNumber(categoryCreateOrUpdateModel.UserId); // Validación de UserId no negativo
                _genericValidator.ValidateDateNotInFuture(categoryCreateOrUpdateModel.ChangeDate); // Validación de ChangeDate
                _genericValidator.ValidateStringWithoutDigits(categoryCreateOrUpdateModel.description, 200);  // Límite de longitud de description

                // Si las validaciones pasan, se guarda en la base de datos
                Category? category = new Category()
                {  
                    categoryname = categoryCreateOrUpdateModel.categoryname,
                    modify_user = categoryCreateOrUpdateModel.UserId,
                    modify_date = categoryCreateOrUpdateModel.ChangeDate,
                    description = categoryCreateOrUpdateModel.description
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                // Manejo de excepciones de validación
                _logger.LogError($"Error al crear categoría: {ex.Message}", ex);
                throw new CategoryDaoException(ex.Message); // Lanzar una excepción personalizada 
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                _logger.LogError("Error inesperado al crear una categoría", ex.ToString());
                throw new CategoryDaoException("Error inesperado al crear una categoría.");
            }
        }

        public GetCategoryModel GetCategoryById(int categoryId)
        {

            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentException("El ID de la categoría no puede ser menor o igual a cero.");
                }

                // Usamos Find para buscar la categoría por su ID
                Category? category = _context.Categories.Find(categoryId);
                if (category == null)
                {
                    throw new ArgumentException("Categoría no encontrada.");
                }

                // Retornamos el modelo de la categoría
                return new GetCategoryModel
                {
                     categoryId = category.categoryid,
                    categoryname = category.categoryname,
                    description = category.description,
                    creation_date = category.creation_date 
                   
                };
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error al obtener la categoría con ID {categoryId}: {ex.Message}", ex);
                throw new CategoryDaoException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al obtener la categoría", ex.ToString());
                throw new CategoryDaoException("Error inesperado al obtener la categoría.");
            }
        }


        public List<GetCategoryModel> GetCategories()
        {
            List<GetCategoryModel> categoriesList = new List<GetCategoryModel>();

            try

            {
                var query = (from category in _context.Categories
                             where category.deleted == false
                             select new GetCategoryModel()
                             {
                               categoryId = category.categoryid, 
                               categoryname = category.categoryname,
                               description = category.description,
                               creation_date = category.creation_date
                             }).ToList();

                
            }
            catch (ArgumentException ex) { _logger.LogError("Error inesperado al obtener la categoría", ex.ToString()); }

            return categoriesList;
        }

        public void ModifyCategory(CategoryCreateOrUpdateModel categoryCreateOrUpdateModel)
        {
            try
            {

               
                // Validar los datos de entrada
                _genericValidator.Validate(categoryCreateOrUpdateModel);

                // Validaciones específicas para los campos
                _genericValidator.ValidateStringWithoutDigits(categoryCreateOrUpdateModel.categoryname, 15);  // Límite de longitud de categoryname
                _genericValidator.ValidateNonNegativeNumber(categoryCreateOrUpdateModel.UserId); // Validación de UserId no negativo
                _genericValidator.ValidateDateNotInFuture(categoryCreateOrUpdateModel.ChangeDate); // Validación de ChangeDate
                _genericValidator.ValidateStringWithoutDigits(categoryCreateOrUpdateModel.description, 200);  // Límite de longitud de description

                Category? categoryToUpdate = _context.Categories.Find(categoryCreateOrUpdateModel.categoryId);

                // Encontrar la categoría a modificar usando Find
                var category = _context.Categories.Find(categoryCreateOrUpdateModel.categoryId);  // Usamos Find aquí


                // Actualizar la categoría
                
                categoryToUpdate.categoryname = categoryCreateOrUpdateModel.categoryname;
                categoryToUpdate.description = categoryCreateOrUpdateModel.description;
                categoryToUpdate.modify_user = categoryCreateOrUpdateModel.UserId;
                categoryToUpdate.modify_date = categoryCreateOrUpdateModel.ChangeDate;
               
                _context.Categories.Update(categoryToUpdate);
                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error al modificar categoría: {ex.Message}", ex);
                throw new CategoryDaoException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al modificar una categoría", ex.ToString());
                throw new CategoryDaoException("Error inesperado al modificar la categoría.");
            }
        }

        public void RemoveCategory(CategoryRemoveModel categoryRemove)
        {
            try
            {
           
                Category? categoryToRemove = _context.Categories.Find(categoryRemove.categoryid);

                categoryToRemove.delete_date = categoryRemove.delete_date;
                categoryToRemove.deleted = true;
                categoryToRemove.delete_user = categoryRemove.delete_user;

                // Eliminar la categoría



                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error al eliminar categoría: {ex.Message}", ex);
                throw new CategoryDaoException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar una categoría", ex.ToString());
                throw new CategoryDaoException("Error inesperado al eliminar la categoría.");
            }
        }

       
    }
}
