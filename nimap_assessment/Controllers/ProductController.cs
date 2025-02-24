using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nimap_assessment.Models;
using nimap_assessment.Service;

namespace nimap_assessment.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
      
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: ProductController
        public ActionResult Index(int pg=1)
        {
            var products = productService.GetAllProducts();

            const int pagesize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = products.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = products.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
           
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var result = productService.GetProductById(id);
            return View(result);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = categoryService.GetAllCaterories();
            //var res = categorydb.GetCategories();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
               
                int result = productService.AddProduct(product);
                if (result >= 1)
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
                ViewBag.Categories = categoryService.GetAllCaterories();
                return View(product);
            }
        }

       

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = categoryService.GetAllCaterories();
            var res=productService.GetProductById(id);
            return View(res);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int response= productService.UpdateProduct(product);
                if (response >= 1)
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = productService.DeleteProduct(id);
            return View(res);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int response= productService.DeleteProduct(id);
                if (response >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }
    }
}
