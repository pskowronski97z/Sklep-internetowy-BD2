﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLogin.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Index]
        [Range(0, 99999.99)]
        public decimal Price { get; set; }

        [Required]
        [Index]
        public String Name { get; set; }

        public String Description { get; set; }

        [Required]
        [Index]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //public int? DiscountId { get; set; }
        //public Discount Discount { get; set; }

        public float? FieldValue1 { get; set; }

        public float? FieldValue2 { get; set; }

        public float? FieldValue3 { get; set; }

        public float? FieldValue4 { get; set; }

        public String FieldValue5 { get; set; }

        public String FieldValue6 { get; set; }

        public String FieldValue7 { get; set; }

        public String FieldValue8 { get; set; }

        public String PictureId { get; set; }

        [Required]
        public int AmountInStore { get; set; }

        public String ProducerName { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}