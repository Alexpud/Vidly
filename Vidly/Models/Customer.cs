﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int Id { get; set; }

        [Display(Name = "Is Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}