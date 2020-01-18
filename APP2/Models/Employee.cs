using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLogin.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Index("IX_LastFirstName", 2)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Index("IX_LastFirstName", 1)]
        public String LastName { get; set; }

        [Required]
        [StringLength(60)]
        public String Email { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime HireDate { get; set; }

        public float Salary { get; set; }

        public int PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public String Login { get; set; }
    }
}