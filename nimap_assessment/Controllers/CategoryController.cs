using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nimap_assessment.Models;

namespace nimap_assessment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        CategoryCrud categorydb;
        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            categorydb = new CategoryCrud(this.configuration);
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var result = categorydb.GetCategories();
            return View(result);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = categorydb.GetCategoryById(id);
            return View(result);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = categorydb.AddCategory(category);
                if (result >= 1)
                {

                     return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong!!!";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = categorydb.GetCategoryById(id);
            return View(res);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int res = categorydb.UpdateCategory(category);
                if (res >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong!!";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = categorydb.GetCategoryById(id);
            return View(res);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int response = categorydb.DeleteCategory(id);
                if(response >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
