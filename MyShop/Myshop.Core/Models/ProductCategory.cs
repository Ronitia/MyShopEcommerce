using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
   public class ProductCategory : BaseEntity
    {
        
        public string Category { get; set; }

        

        public ProductCategory Find(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
