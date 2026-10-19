using System.Diagnostics;
using ContactBook.Models;
using ContactBook.Service;
using ContactBook.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public IActionResult ContactDetail(Contact contact)
        {
            return View(contact);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact != null)
            {
                _contactService.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Update(int id)
        {
            var contact = _contactService.GetById(id);
            _contactService.Update(contact);
            return View(contact);
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
