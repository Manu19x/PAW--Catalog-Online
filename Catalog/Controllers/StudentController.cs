using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Catalog.Data;
using Catalog.Models;
using Catalog.ViewModels;
using System.Collections.Generic;

namespace Catalog.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly CatalogContext _context;

        public StudentController(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var student = await _context.Students
                .Include(s => s.UserAccount)
                .FirstOrDefaultAsync(s => s.UserAccount.Email == userId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Cursuri()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var student = await _context.Students
                .Include(s => s.UserAccount)
                .Include(s => s.InscrieriCursuri)
                .ThenInclude(ic => ic.Curs)
                .FirstOrDefaultAsync(s => s.UserAccount.Email == userId);

            if (student == null)
            {
                return NotFound();
            }

            var cursuri = student.InscrieriCursuri.Select(ic => ic.Curs).ToList();
            return View(cursuri);
        }

        public async Task<IActionResult> Note()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var student = await _context.Students
                .Include(s => s.UserAccount)
                .Include(s => s.InscrieriCursuri)
                .ThenInclude(ic => ic.Curs)
                .FirstOrDefaultAsync(s => s.UserAccount.Email == userId);

            if (student == null)
            {
                return NotFound();
            }

            var notePeAni = student.InscrieriCursuri
                .GroupBy(ic => ic.Curs.AnUniversitar)
                .Select(g => new NotePeAnViewModel
                {
                    AnUniversitar = g.Key,
                    Note = g.ToList(),
                    Media = (double)g.Average(n => n.Nota)
                }).ToList();

            return View(notePeAni);
        }
    }
}
