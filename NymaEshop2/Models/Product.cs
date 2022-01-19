using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NymaEshop2.Models
{
    public class Product
    {
       
        public int Id { get; set; }
        public string NamePD { get; set; }
        public string DescriptionPD { get; set; }
        
        public int ItemID { get; set; }

        public Item Item { get; set; }


        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }


    }
}
