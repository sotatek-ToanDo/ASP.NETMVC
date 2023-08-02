using App.Services;
using ASP.NETMVC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        public readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger , ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            //this.HTTPContext
            //This.Request
            //this.Response
            //this.RouteData

            //this.User
            //this.ModelState
            //this.ViewData
            //this.ViewBag
            //this.TempData
            Console.WriteLine("Index Action");
            _logger.LogWarning("thong bao abc");
            _logger.LogError("THong bao");
            _logger.LogInformation("Index Action");
            return "Toi la Index cua First";
        }
        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "Xin chao cac ban");
        }
        public object Anything() => DateTime.Now;
        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban

            Cac ban dang hoc MVC";
            return Content(content,"text/plain");

        }
        public IActionResult Bird()
        {
            //Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "bird.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "images/png");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new { 
                    productName = "Iphone",
                    price = 10000
                });
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy","Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url);
        }
        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url);
        }
        //ViewResult | View()
        public IActionResult HelloView(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                userName = "Khach";
            //View -> Razor Engine. doc .cshtml
            //View(Template) temp duong dan tuyet doi voi .cshtml
            //View(template,model)
            //return View("/Myview/Xinchao.cshtml", userName);
            //return View("Xinchao2", userName);
            //Helloview.cshtml -> View/First/HelloView
            //return View((object) userName);
            return View("Xin chao3", userName);
            //View()
            //ViewModel()
        }
        [TempData]
        public string StatusMessage { get; set; }
        public IActionResult ViewProduct(int ?id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["Thongbao"] = "KHong co san pham nay";
                StatusMessage = " san pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
            //View/first/ViewProduct.cshtml
            //return View(product);
            //viewData
            //this.ViewData["product"] = product;
            //ViewData["Title"] = product.Name;

            //ViewBag.product = product;
            //return View("ViewProduct3");
            return View("ViewProduct3");

        }

    }
}
