using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebsite.Pages
{
    public class ProductsByCategoryModel : PageModel
    {
        private readonly ShoppingDbContext _context;

        public ProductsByCategoryModel(ShoppingDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public string CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            CategoryName = category.Name;

            Products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            Categories = await _context.Categories.ToListAsync();

            if (Products == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
