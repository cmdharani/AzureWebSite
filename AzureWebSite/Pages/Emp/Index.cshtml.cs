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
    public class IndexModel : PageModel
    {
        private readonly AzureWebSite.Data.AppDbContext _context;

        public IndexModel(AzureWebSite.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<AzureWebSite.Data.Emp> Emp { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Emp = await _context.Emps.ToListAsync();
        }
    }
}
