using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureWebSite.Data;

namespace AzureWebSite.Pages.Emp
{
    public class DetailsModel : PageModel
    {
        private readonly AzureWebSite.Data.AppDbContext _context;

        public DetailsModel(AzureWebSite.Data.AppDbContext context)
        {
            _context = context;
        }

        public AzureWebSite.Data.Emp Emp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps.FirstOrDefaultAsync(m => m.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                Emp = emp;
            }
            return Page();
        }
    }
}
