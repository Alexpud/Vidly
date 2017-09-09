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
        List<Customer> movies; 
        private ApplicationDbContext _context;

        #region Constructor

        public CustomerController()
        {
            _context = new ApplicationDbContext();
            movies = new List<Customer>()
            {
                new Customer()
                {
                    Name = "John Smith",
                    Id =  1
                },
                new Customer()
                {
                    Name = "Mary Williams",
                    Id = 2
                }
            };
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
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);

            //var result = movies.FirstOrDefault(x => x.Id == customerId);

            return View(customer);
        }
    }
}