using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public object Mapper { get; private set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
      
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipType = _context.MemberShipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = membershipType
            };
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershipType = _context.MemberShipType.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    MemberShipTypes = membershipType,
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customer.Add(customer);
                //return Content("new customer"+customer.Id + "" + customer.Birthdate + "" + customer.MemberShipTypeId + "" + customer.IsSubscribToNewsLetter);

            }
            else
            {
                var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb)
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribToNewsLetter = customer.IsSubscribToNewsLetter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.Birthdate = customer.Birthdate;

               //return Content(customer.Name+"a7a"+customerInDb.Name+"" +customer.Id + "<<<" + customer.Birthdate + "" + customer.MemberShipTypeId + "" + customer.IsSubscribToNewsLetter);
            }

            
            _context.SaveChanges();
            
            
             
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

       
   
   }
}