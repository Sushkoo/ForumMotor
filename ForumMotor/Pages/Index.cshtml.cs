﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ForumMotor.Data;
using ForumMotor.Models;

namespace ForumMotor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public IndexModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Kategoria> Kategoria { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kategoria = await _context.Kategoriak
                .Include(k => k.User).ToListAsync();
        }
    }
}
