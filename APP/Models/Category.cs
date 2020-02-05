using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLogin.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Index]
        public String Name { get; set; }

        [StringLength(50)]
        public String FieldName1 { get; set; }

        [StringLength(50)]
        public String FieldName2 { get; set; }

        [StringLength(50)]
        public String FieldName3 { get; set; }

        [StringLength(50)]
        public String FieldName4 { get; set; }

        [StringLength(50)]
        public String FieldName5 { get; set; }

        [StringLength(50)]
        public String FieldName6 { get; set; }

        [StringLength(50)]
        public String FieldName7 { get; set; }

        [StringLength(50)]
        public String FieldName8 { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}