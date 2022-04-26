using Homework2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder)
        {
            var contacts = new[]
            {
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
    };

            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id":
                        {
                            contacts = contacts.OrderBy(c => c.Id).ToArray<Contact>();
                            break;
                        }
                    case "name":
                        {
                            contacts = contacts.OrderBy(c => c.Name).ToArray<Contact>();
                            break;
                        }
                    case "city":
                        {
                            contacts = contacts.OrderBy(c => c.City).ToArray<Contact>();
                            break;
                        }
                    case "state":
                        {
                            contacts = contacts.OrderBy(c => c.State).ToArray<Contact>();
                            break;
                        }
                    case "phone":
                        {
                            contacts = contacts.OrderBy(c => c.Phone).ToArray<Contact>();
                            break;
                        }
                }
            }

            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}