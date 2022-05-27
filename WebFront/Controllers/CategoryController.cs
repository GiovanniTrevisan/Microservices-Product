﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebFront.Data;
using WebFront.Models;

namespace WebFront.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WebFrontContext _context;
        private readonly Uri baseAddress = new Uri("https://localhost:7264/");
        private readonly string callRequest = "api/Categories/category";

        public CategoryController(WebFrontContext context)
        {
            _context = context;
        }

        // GET: CategoryViewModels
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryViewModel> categoriesList = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.GetAsync(callRequest);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<CategoryViewModel>>();
                readTask.Wait();
                categoriesList = readTask.Result;
            }

            return categoriesList != null ?
                          View(categoriesList.ToList()) :
                          Problem("Category Section is null.");
        }

        // GET: CategoryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            CategoryViewModel? category = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }

            return category == null ? NotFound() : View(category);
        }

        // GET: CategoryViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.PostAsync(callRequest, categoryViewModel, new JsonMediaTypeFormatter());
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            CategoryViewModel? category = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }

            return category == null ? NotFound() : View(category);
        }

        // POST: CategoryViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (id == null)
                return NotFound();

            CategoryViewModel? category = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.PutAsync(callRequest + "/" + id, categoryViewModel, new JsonMediaTypeFormatter());
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }
            return category == null ? NotFound() : View(category);
        }

        // GET: CategoryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            CategoryViewModel? category = null;

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.GetAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }

            return category == null ? NotFound() : View(category);
        }

        // POST: CategoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            using (var categoryClient = new HttpClient())
            {
                categoryClient.BaseAddress = baseAddress;
                var responseTask = categoryClient.DeleteAsync(callRequest + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                var readTask = result.Content.ReadFromJsonAsync<CategoryViewModel>();
                readTask.Wait();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
