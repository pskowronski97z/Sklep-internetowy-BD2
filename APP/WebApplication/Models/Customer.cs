using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]      
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Range(0,99999.99)]
        public decimal BasketValue { get; set; }
   
        public Address Address { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }
      
        [Required]
        [StringLength(60)]
        public string Login { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}