using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFront.Models;

namespace WebFront.Controllers
{
    public class ProductsController : Controller
    {

        private readonly Uri baseAddress = new Uri("https://localhost:7003/");
        private readonly string callRequest = "api/v1/Products/product";

        // GET: Products
        public ActionResult Index()
        {

            IEnumerable<ProductViewModel> productsList = null;

            using (var products = new HttpClient())
            {
                products.BaseAddress = baseAddress;
                var responseTask = products.GetAsync(callRequest);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<ProductViewModel>>();
                readTask.Wait();
                productsList = readTask.Result;
            }

            return View(productsList);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel productViewModel = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<ProductViewModel>();
                readTask.Wait();
                productViewModel = readTask.Result;
            }

            return productViewModel != null ?
                          View(productViewModel) :
                          Problem("Product Selected does not exist!");

        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            string productDeletedMessage = "";

            using (var products = new HttpClient())
            {
                products.BaseAddress = new Uri("https://localhost:7003/");

                var responseTask = products.DeleteAsync("api/v1/Products/product/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    productDeletedMessage = readTask.Result;

                }
                else //web api sent error response 
                {

                    productDeletedMessage = "Product not found!";
                    ModelState.AddModelError(string.Empty, productDeletedMessage);

                }
            }
            return View(productDeletedMessage);
        }

        // POST: Products/Delete/5
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
