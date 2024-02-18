using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context context = new Context();

        public ActionResult ContactList()
        {
            var contactlist=context.Contacts.Where(x=>x.Status==true).ToList();
            return View(contactlist);
        }
        public ActionResult Index(int id)
        {
            var contact = context.Contacts.Where(x=>x.CustomerId==id).ToList();

            return View(contact);
        }

        [HttpGet]
        public ActionResult AddContact(int id)
        {
            
            var contact=context.Customers.Where(x=>x.ID==id).Select(y=>y.ID).FirstOrDefault();
            ViewBag.contact=contact;            

            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            contact.Status = true;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");



        }
        [HttpGet]
        public ActionResult EditContact(int id)
        {
            var contact = context.Customers.Where(x => x.ID == id).Select(y => y.ID).FirstOrDefault();
            ViewBag.contact= contact;
            var editcontact = context.Contacts.Where(x => x.ID == id).FirstOrDefault();
            return View(editcontact);
        }
        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            var editcontact=context.Contacts.Where(x=>x.ID==contact.ID).FirstOrDefault();
           
            editcontact.FirstName = contact.FirstName;
            editcontact.LastName = contact.LastName;
            editcontact.Position= contact.Position;
            editcontact.Email = contact.Email;
            editcontact.Phone = contact.Phone;
            editcontact.CustomerId = contact.CustomerId;
            context.SaveChanges();
            return RedirectToAction("Index","Customer");

        }

        public ActionResult DeleteContact(int id)
        {
            var deletecontact=context.Contacts.Where(x=>x.ID == id).FirstOrDefault();
            deletecontact.Status = false;
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}