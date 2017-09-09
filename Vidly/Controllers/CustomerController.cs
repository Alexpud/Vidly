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

        // GET: Customer
        public ActionResult Index()
        {
            CustomerModel model = new CustomerModel();
            var customers = _context.Customers;
            model.Customers = customers.Include("MembershipType").ToList();
            return View(model);
        }

        public ActionResult Details(int customerId)
        {
            var customer = _context.Customers.Include("MembershipType").FirstOrDefault(x => x.Id == customerId);

            return View(customer);
        }
    }
}