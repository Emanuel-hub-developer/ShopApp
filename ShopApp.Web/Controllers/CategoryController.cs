using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.DAL.Interfaces;
using ShopApp.DAL.Models.Category;

namespace ShopApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDaoCategory _daocategory;

        public CategoryController(IDaoCategory daocategory)
        {
            _daocategory = daocategory;
        }


        // GET: CategoryController
        public ActionResult Index()
        {
            var category = _daocategory.GetCategories();
            return View(category);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _daocategory.GetCategoryById(id);
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create(CategoryCreateOrUpdateModel createmodel)
        {
            try
            {  
                _daocategory.CreateCategory(createmodel);   
                return RedirectToAction(nameof(Index));
            }catch
            {
                return View();
            }
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
