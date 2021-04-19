﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Identity;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData) { _ProductData = ProductData; }

        public IActionResult Index() => View(_ProductData.GetProducts());
    }
}
