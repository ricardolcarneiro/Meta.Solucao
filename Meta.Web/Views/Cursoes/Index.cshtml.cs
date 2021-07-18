using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Meta.Web.Models;

namespace Meta.Web.Views.Curso
{
    public class IndexModel : PageModel
    {
        private readonly Meta.Web.Models.AppDbContext _context;

        public IndexModel(Meta.Web.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Meta.Web.Models.Curso> Curso { get;set; }

        public async Task OnGetAsync()
        {
            Curso = await _context.Cursos.ToListAsync();
        }
    }
}
