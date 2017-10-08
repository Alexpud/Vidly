using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        #region Constructor

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion

        #region Index

        public ActionResult Index()
        {
            CustomerModel model = new CustomerModel();
            var customers = _context.Customers;
            model.Customers = customers.Include("MembershipType").ToList();
            return View(model);
        }

        #endregion

        #region New - GET

        public ActionResult New(CustomerModel model)
        {
            var memberships = _context.MembershipTypes.ToList();
            ViewBag.Memberships = memberships;

            return View(model);
        }

        #endregion

        #region New - POST

        [HttpPost]
        public ActionResult NewPost(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                var memberships = _context.MembershipTypes.ToList();
                ViewBag.Memberships = memberships;
                return View("New", model);
            }

            _context.Customers.Add(model.Customer);
            var result = _context.SaveChanges();
            if (result != 1)
                TempData["ErrorMessage"] = "Failed to create new customer.";

            TempData["SuccessMessage"] = "Customer was successfully created.";
            return RedirectToAction("Index");
        }

        #endregion

        #region Details

        public ActionResult Details(int customerId)
        {
            var customer = _context.Customers.Include("MembershipType").FirstOrDefault(x => x.Id == customerId);
            CustomerModel model = new CustomerModel();
            model.Customer = customer;
            return View(model);
        }

        #endregion

        #region Edit - GET
        public ActionResult Edit(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            var memberships = _context.MembershipTypes.ToList();
            ViewBag.Memberships = memberships;

            CustomerModel model = new CustomerModel();
            model.Customer = customer;

            return View(model);
        }
        #endregion

        #region Edit - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                var memberships = _context.MembershipTypes.ToList();
                ViewBag.Memberships = memberships;
                return View("Edit", model);
            }

            var elem = _context.Customers.FirstOrDefault(c => c.Id == model.Customer.Id);
            if (elem != null)
            {
                elem.MembershipTypeId = model.Customer.MembershipTypeId;
                elem.Name = model.Customer.Name;
                elem.BirthDate = model.Customer.BirthDate;
                elem.IsSubscribedToNewsLetter = model.Customer.IsSubscribedToNewsLetter;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion

    }
}