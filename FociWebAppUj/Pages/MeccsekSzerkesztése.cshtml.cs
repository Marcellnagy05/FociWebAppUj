using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FociWebAppUj.Models;

namespace FociWebAppUj.Pages
{
    public class MeccsekSzerkesztéseModel : PageModel
    {
        private readonly FociWebAppUj.Models.FociDbContext _context;

        public MeccsekSzerkesztéseModel(FociWebAppUj.Models.FociDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meccs Meccs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meccs =  await _context.Meccsek.FirstOrDefaultAsync(m => m.Id == id);
            if (meccs == null)
            {
                return NotFound();
            }
            Meccs = meccs;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meccs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeccsExists(Meccs.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./MeccsekListazasa");
        }

        private bool MeccsExists(int id)
        {
            return _context.Meccsek.Any(e => e.Id == id);
        }
    }
}
