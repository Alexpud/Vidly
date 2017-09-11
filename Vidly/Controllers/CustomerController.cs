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

        public ActionResult New()
        {
            var memberships = _context.MembershipTypes.ToList();
            ViewBag.Memberships = memberships;

            return View();
        }

        #endregion

        #region New - POST

        [HttpPost]
        public ActionResult New(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Details

        public ActionResult Details(int customerId)
        {
            var customer = _context.Customers.Include("MembershipType").FirstOrDefault(x => x.Id == customerId);

            return View(customer);
        }

        #endregion

        #region Edit - GET
        public ActionResult Edit(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            var memberships = _context.MembershipTypes.ToList();
            ViewBag.Memberships = memberships;

            return View(customer);
        }
        #endregion

        #region Edit - POST

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var elem = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (elem != null)
            {
                elem.MembershipTypeId = customer.MembershipTypeId;
                elem.Name = customer.Name;
                elem.BirthDate = customer.BirthDate;
                elem.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion

    }
}