﻿using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet("/Products")]
        public IActionResult ProductsHome()
        {
            return this.View();
        }
    }
}
