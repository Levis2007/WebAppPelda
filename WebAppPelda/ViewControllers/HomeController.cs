using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppPelda.Models;
using WebAppPelda.Services;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vasarlo(int id)
        {
            Customer customer = new CustomerService().GetById(id);
            return View(customer);
        }

        public IActionResult Sajat()
        {
            List<Customer> customers = new CustomerService().GetAllCustomer();
            return View(customers);
        }

        //CreateCustomer dolgai
        [HttpGet]
        public IActionResult CreateCustomer() 
        {
            Customer emptyCustomer = new Customer();
            return View(emptyCustomer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer) 
        {
            string result = new CustomerService().PostCustomer(customer);
            TempData["SuccessMessage"] = result;
            return RedirectToAction(nameof(CreateCustomer));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
