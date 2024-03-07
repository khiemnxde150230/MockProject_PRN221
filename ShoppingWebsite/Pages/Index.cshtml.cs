using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShoppingLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ShoppingDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ShoppingDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            Products = _dbContext.Products.OrderByDescending(p => p.ProductId).ToList();
            Categories = _dbContext.Categories.ToList();
        }
    }
}
