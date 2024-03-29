﻿using Microsoft.AspNetCore.Mvc;
using ShoppingList.Contracts;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        public async Task <IActionResult> Index()
        {
            var model = await productService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

             await productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            var model = await productService.GetByIdAsync(id);

            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult>Edit(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            await productService.UpdateProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           await  productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
