using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Basket
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Range(1, 999)]
        public int AmountInBasket { get; set; }
    }
}