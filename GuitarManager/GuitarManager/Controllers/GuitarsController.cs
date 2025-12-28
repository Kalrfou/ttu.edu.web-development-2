using GuitarManager.data;
using GuitarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarManager.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly GuitarDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GuitarsController(GuitarDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guitars.ToListAsync());
        }
        // CREATE
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guitar guitar, IFormFile imageFile)
        {
            // 1️⃣ Validate model (data annotations)
            if (!ModelState.IsValid)
                return View(guitar);

            // 2️⃣ Handle image upload (if user selected an image)
            if (imageFile != null && imageFile.Length > 0)
            {
                // Path to wwwroot/images
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");

                // Ensure folder exists
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Generate unique filename (prevents overwrite)
                string uniqueFileName = Guid.NewGuid().ToString()
                                        + Path.GetExtension(imageFile.FileName);

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save image to server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Save relative path to database (NOT the file)
                guitar.ImagePath = "/images/" + uniqueFileName;
            }

            // 3️⃣ Save guitar record to database
            _context.Add(guitar);
            await _context.SaveChangesAsync();

            // 4️⃣ Redirect to Index after success
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null) return NotFound();
            return View(guitar);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Guitar guitar)
        {
            if (!ModelState.IsValid)
                return View(guitar);


            _context.Update(guitar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null) return NotFound();
            return View(guitar);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar != null)
            {
                _context.Guitars.Remove(guitar);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
