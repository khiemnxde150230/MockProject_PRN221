﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingLibrary.Models;

namespace ShoppingWebsite.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ShoppingLibrary.Models.ShoppingDbContext _context;

        public DetailsModel(ShoppingLibrary.Models.ShoppingDbContext context)
        {
            _context = context;
        }

      public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                                        .Include(p => p.Category) // Ensure Category is loaded
                                        .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

    }
}
