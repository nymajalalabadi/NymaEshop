using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NymaEshop2.Models
{
    public class Category
    {
        public int Id { get; set; }


        public string NameCT { get; set; }

        

        public string DesvriptionCT { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
