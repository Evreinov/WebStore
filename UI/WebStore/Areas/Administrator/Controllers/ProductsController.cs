﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Identity;
using WebStore.Interfaces.Services;

namespace WebStore.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData) { _ProductData = ProductData; }

        public IActionResult Index() => View(_ProductData.GetProducts());

        public IActionResult Edit(int id) =>
            _ProductData.GetProductById(id) is { } product
            ? View(product)
            : NotFound();

        public IActionResult Delete(int id) =>
            _ProductData.GetProductById(id) is { } product
            ? View(product)
            : NotFound();
    }
}

