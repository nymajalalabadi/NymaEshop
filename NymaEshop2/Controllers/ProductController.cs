using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NymaEshop2.Data;
using NymaEshop2.Models;
using Microsoft.EntityFrameworkCore;

namespace NymaEshop2.Controllers
{
    public class ProductController : Controller
    {

        private MyEshopContext _context;

        public ProductController(MyEshopContext context)
        {
            _context = context;
        }



        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {

            ViewData["GroupName"] = name;


            var product = _context.CategoryToProducts.Where(i => i.Categoryid == id)
                .Include(i => i.Product)
                .Select(i => i.Product)
                .ToList();

            return View(product);
        }
    }
}
