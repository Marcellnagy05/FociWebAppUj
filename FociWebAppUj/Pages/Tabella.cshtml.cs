using FociWebAppUj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace FociWebAppUj.Pages
{
    public class TabellaModel : PageModel
    {
        List<Allas> tabella = new List<Allas>();
        private readonly FociWebAppUj.Models.FociDbContext _context;

        public TabellaModel(FociWebAppUj.Models.FociDbContext context)
        {
            _context = context;
        }

        public IList<Meccs> Meccs { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.Meccsek.ToListAsync();
        }
        public void TabellaGenerator()
        {
            tabella.ForEach(allas => { 
                
            });
        }
    }
}
