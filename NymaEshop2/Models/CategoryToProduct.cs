using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NymaEshop2.Models
{
    public class CategoryToProduct
    {

        public int Categoryid { get; set; }
        public int Productid { get; set; }




        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
