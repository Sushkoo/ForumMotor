using System;
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
    public class PostLitsModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public PostLitsModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int TopicId {  get; set; }

        public IList<Bejegyzes> Bejegyzes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bejegyzes = await _context.Bejegyzesek
                .Where(x=>x.TopicId == TopicId)
                .Include(b => b.Topic)
                .Include(b => b.User).ToListAsync();
        }
    }
}
