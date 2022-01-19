using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NymaEshop2.Data;
using NymaEshop2.Models;

namespace NymaEshop2.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyEshopContext _context;

        public AddModel(MyEshopContext context)
        {
            _context = context;
        }


        [BindProperty]
        public AddEditProductViewModel product { get; set; }


        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public void OnGet()
        {
            product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                PriceIT = product.Price,
                QuantityInStock = product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                NamePD = product.Name,
                Item = item,
                DescriptionPD = product.Description,

            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemID = pro.Id;
            _context.SaveChanges();

            if (product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }
            }

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        Categoryid = gr,
                        Productid = pro.Id
                    });
                }

                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
