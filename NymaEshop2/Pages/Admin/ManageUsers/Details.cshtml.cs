﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NymaEshop2.Data;
using NymaEshop2.Models;

namespace NymaEshop2.Pages.Admin.ManageUsers
{
    public class DetailsModel : PageModel
    {
        private readonly NymaEshop2.Data.MyEshopContext _context;

        public DetailsModel(NymaEshop2.Data.MyEshopContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
