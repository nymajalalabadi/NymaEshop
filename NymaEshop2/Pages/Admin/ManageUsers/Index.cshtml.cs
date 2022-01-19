using System;
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
    public class IndexModel : PageModel
    {
        private readonly NymaEshop2.Data.MyEshopContext _context;

        public IndexModel(NymaEshop2.Data.MyEshopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.users.ToListAsync();
        }
    }
}
