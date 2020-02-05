using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopLogin.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string City { get; set; }

        [StringLength(60)]
        public string Street { get; set; }

        [StringLength(10)]
        public string Building { get; set; }

        [StringLength(10)]
        public string Apartment { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

    }
}