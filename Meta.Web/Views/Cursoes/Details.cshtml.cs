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
    public class DetailsModel : PageModel
    {
        private readonly Meta.Web.Models.AppDbContext _context;

        public DetailsModel(Meta.Web.Models.AppDbContext context)
        {
            _context = context;
        }

        public Meta.Web.Models.Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curso = await _context.Cursos.FirstOrDefaultAsync(m => m.Id == id);

            if (Curso == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
