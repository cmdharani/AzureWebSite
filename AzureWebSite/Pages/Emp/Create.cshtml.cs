using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AzureWebSite.Data;

namespace AzureWebSite.Pages.Emp
{
    public class CreateModel : PageModel
    {
        private readonly AzureWebSite.Data.AppDbContext _context;

        public CreateModel(AzureWebSite.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AzureWebSite.Data.Emp Emp { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Emps.Add(Emp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
