using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository contactRepository;

        public HomeController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public ViewResult Index()
        {
            return View(contactRepository.getAllContacts());
        }

        public ViewResult Details(int id)
        {
            return View(contactRepository.getContact(id));
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        public ViewResult Update(int id)
        {
            return View("Create",contactRepository.getContact(id));
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            contact.Status = contact.Status ?? "InActive";
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                {
                    contact.Status = contact.Status ?? "InActive";
                    contactRepository.addContact(contact);

                }
                else
                {
                    contactRepository.updateContact(contact);
                }
                return RedirectToAction("Details", new { id = contact.Id });
            }

            return View();
        }
    }
}
