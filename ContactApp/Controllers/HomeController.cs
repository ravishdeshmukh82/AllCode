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
            Contact contact = contactRepository.getContact(id);
            if (contact != null)
            {
                return View(contactRepository.getContact(id));
            }
            else
            {
                return View("NotFound",id);
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Title = "Create Contact";
            return View();
        }
        public ViewResult Update(int id)
        {
            ViewBag.Title = "Edit Contact";
            return View("Create",contactRepository.getContact(id));
        }
        public IActionResult Delete(int id)
        {
            
            contactRepository.deleteContact(id);
           return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            //contact.Id = contact.Id ?? 0;
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
