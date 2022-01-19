using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NymaEshop2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public decimal PriceIT { get; set; }
        public int QuantityInStock { get; set; }

    }
}
