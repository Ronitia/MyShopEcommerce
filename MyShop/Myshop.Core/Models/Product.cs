﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
    public class Product : BaseEntity
    {
        

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }


       
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        [Range(0, 1000)]
        public Decimal Price { get; set; }

   

    }
}
