using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public float BasketValue { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        
    }
}