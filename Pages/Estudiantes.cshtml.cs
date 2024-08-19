using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen2.Data; 
using Examen2.Models; 

namespace Examen2.Pages
{
    public class EstudiantesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public async Task OnGetAsync()
        {
            Estudiantes = await _context.Estudiantes.ToListAsync();
        }
    }
}
