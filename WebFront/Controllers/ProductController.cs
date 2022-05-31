using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFront.Models;

namespace WebFront.Controllers
{
    public class ProductController : Controller
    {

        private readonly Uri baseAddress = new Uri("https://localhost:7003/");
        private readonly string callRequest = "api/v1/Products/product";

        public ProductController()
        {
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> productsList = null;

            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var responseTask = productClient.GetAsync(callRequest);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<ProductViewModel>>();
                readTask.Wait();
                productsList = readTask.Result;
            }

            return productsList != null ?
                          View(productsList.ToList()) :
                          Problem("Product Section is null.");
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            ProductViewModel? product = null;

            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var responseTask = productClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<ProductViewModel>();
                readTask.Wait();
                product = readTask.Result;
            }

            return product == null ? NotFound() : View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            List<CategoryViewModel> categoriesList = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = new Uri("https://localhost:7264/");
                var responseTask = categoryClient.GetAsync("api/Categories/category");
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<CategoryViewModel>>();
                readTask.Wait();
                categoriesList = readTask.Result.ToList();
            }

            ViewBag.CategoriesList = categoriesList;

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,OutOfStock,IdCategory")] ProductViewModel productViewModel)
        {
            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var result = await productClient.PostAsync(callRequest, productViewModel, new JsonMediaTypeFormatter());

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var ret = await result.Content.ReadAsStringAsync();
                }
            }
            return Problem("Some problem occurred. Cannot Save this new Product!");
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
                return NotFound();

            List<CategoryViewModel> categoriesList = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = new Uri("https://localhost:7264/");
                var result = await categoryClient.GetAsync("api/Categories/category");
                var readTask = await result.Content.ReadFromJsonAsync<IEnumerable<CategoryViewModel>>();
                categoriesList = readTask.ToList();
            }

            ViewBag.CategoriesList = categoriesList;

            ProductViewModel? product = null;

            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var result = await productClient.GetAsync(callRequest + "/" + id);
                product = await result.Content.ReadFromJsonAsync<ProductViewModel>();
                product.IdCategory = product.Category.Id;
            }

            return product == null ? NotFound() : View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,OutOfStock")] ProductViewModel productViewModel)
        {
            if (id == null)
                return NotFound();

            ProductViewModel? product = null;

            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var responseTask = productClient.PutAsync(callRequest + "/" + id, productViewModel, new JsonMediaTypeFormatter());
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<ProductViewModel>();
                readTask.Wait();
                product = readTask.Result;
            }
            return product == null ? Problem("Some problem occurred. Cannot Edit this Product!") : RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            ProductViewModel? product = null;

            using (var productClient = new HttpClient())
            {
                productClient.BaseAddress = baseAddress;
                var responseTask = productClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<ProductViewModel>();
                readTask.Wait();
                product = readTask.Result;
            }

            return product == null ? NotFound() : View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isDeleted = false;

            if (id == 0)
                return NotFound();

            using (var problemClient = new HttpClient())
            {
                problemClient.BaseAddress = baseAddress;
                var responseTask = problemClient.DeleteAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadAsStringAsync().Result;
                isDeleted = Convert.ToBoolean(readTask);
            }
            return isDeleted ? RedirectToAction(nameof(Index)) : Problem("Some problem occurred. Cannot Delete this value!");
        }
    }
}
