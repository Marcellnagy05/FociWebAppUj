using FociWebAppUj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebAppUj.Pages
{
    public class ImportDataFromFilesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly FociDbContext _context;

        public ImportDataFromFilesModel(IWebHostEnvironment env, FociDbContext context)
        {
            _env = env;
            _context = context;
        }

        [BindProperty]
        public IFormFile? Upload { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Upload == null || Upload.Length == 0)
            {
                ModelState.AddModelError("Upload", "Import another file!");
                return Page();
            }

            var UploadDirPath = Path.Combine(_env.ContentRootPath, "upload");
            var UploadFilePath = Path.Combine(UploadDirPath, Upload.FileName);

            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await Upload.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var items = line.Split(" ");

                Meccs ujMeccs = new Meccs();
                ujMeccs.Fordulo = int.Parse(items[0]);
                ujMeccs.HazaiVeg = int.Parse(items[1]);
                ujMeccs.VendegVeg = int.Parse(items[2]);
                ujMeccs.HazaiFelido = int.Parse(items[3]);
                ujMeccs.VendegFelido = int.Parse(items[4]);
                ujMeccs.HazaiCsapat = items[5];
                ujMeccs.VendegCsapat = items[6];

                _context.Meccsek.Add(ujMeccs);
            }

            sr.Close();
            _context.SaveChanges();

            System.IO.File.Delete(UploadFilePath);

            return Page();
        }
    }
}
