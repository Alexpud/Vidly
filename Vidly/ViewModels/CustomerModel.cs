﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerModel
    {
        public List<Customer> Customers { get; set; }
        public int CustomerrId { get; set; }
    }
}