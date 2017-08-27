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
        List<Customer> movies { get; set; }


        #region Constructor

        public CustomerController()
        {
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

        #endregion

        // GET: Customer
        public ActionResult Index()
        {
            CustomerModel model = new CustomerModel();
            model.Customers = this.movies;
            return View(model);
        }

        public ActionResult Details(int customerId)
        {
            var result = movies.FirstOrDefault(x => x.Id == customerId);

            return View(result);
        }
    }
}