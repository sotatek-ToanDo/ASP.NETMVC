using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController: Controller
    {
        public readonly ProductService _productService;
        public readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [Route("cac-san-pham")]
    public IActionResult Index()
        {
            //Area/AreaName/Views/ControllerName/Action.cshtml
            var products = _productService.OrderBy(p => p.Name).ToList();

            return View(products); //Area/ProductManage/Views/ProductManage/Index
        }
    }
}
