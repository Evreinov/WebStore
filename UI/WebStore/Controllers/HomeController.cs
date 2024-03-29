﻿using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Shop() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult CheckOut() => View();

        public IActionResult Cart() => View();

        public IActionResult Login() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Error404() => View();

        public IActionResult ErrorStatus(string code) => code switch
        {
            "404" => RedirectToAction(nameof(Error404)),
            _ => Content($"Error code: {code}")
        };

        public IActionResult ContactUs() => View();
    }
}
