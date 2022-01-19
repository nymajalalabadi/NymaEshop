using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NymaEshop2.Data;
using NymaEshop2.Models;

namespace NymaEshop2.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MyEshopContext _context;

        public EditModel(MyEshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public List<int> GoupsProduct { get; set; }

        public void OnGet(int id)
        {
            var product = _context.Products.Include(p => p.Item)
                .Where(p => p.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.Id,
                    Name = s.NamePD,
                    Description = s.DescriptionPD,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.PriceIT
                }).FirstOrDefault();

            Product = product;
            product.Categories = _context.Categories.ToList();
            GoupsProduct = _context.CategoryToProducts.Where(c => c.Productid == id).
                Select(c => c.Categoryid).ToList();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.ItemID);

            product.NamePD = Product.Name;
            product.DescriptionPD = Product.Description;
            item.PriceIT = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;

            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            _context.CategoryToProducts.Where(c => c.Productid == Product.Id).ToList()
               .ForEach(g => _context.CategoryToProducts.Remove(g));

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        Categoryid = gr,
                        Productid = product.Id
                    });
                }

                _context.SaveChanges();
            }


            return RedirectToPage("Index");
        }
    }
}
