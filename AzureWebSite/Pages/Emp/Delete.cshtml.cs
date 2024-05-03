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
    public class DeleteModel : PageModel
    {
        private readonly AzureWebSite.Data.AppDbContext _context;

        public DeleteModel(AzureWebSite.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps.FindAsync(id);
            if (emp != null)
            {
                Emp = emp;
                _context.Emps.Remove(Emp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
