using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController: Controller
    {
        private readonly PanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
        //Route
        [Route("/danh-sach-Cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        //route:Action
        [BindProperty(SupportsGet = true , Name= "action" )]

        public string Name { get; set; }
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail",planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        [Route("sao/[action]" ,Order =3, Name ="neptune3")] //sao/action
        [Route("sao/[controller]/[action]" , Order = 2, Name = "neptune2")] // sao/Planet/Neptune
        [Route("[controller]-[action].html" ,Order = 1, Name = "neptune1")] // Planet-Neptune.html

        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
        //controller,action,area [controller] [action] [area]
        [Route("hanh-tinh/{id:int}")]
       public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            Console.WriteLine(planet);
            return View("Detail", planet);
        }
    }
}
