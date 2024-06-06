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

        public async Task<IActionResult> Cursuri(string sortOrder, string searchString)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var student = await _context.Students
                .Include(s => s.UserAccount)
                .Include(s => s.InscrieriCursuri)
                .ThenInclude(ic => ic.Curs)
                .ThenInclude(c => c.Profesor)
                .FirstOrDefaultAsync(s => s.UserAccount.Email == userId);

            if (student == null || student.InscrieriCursuri == null)
            {
                return NotFound();
            }

            var cursuri = student.InscrieriCursuri.AsQueryable();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                cursuri = cursuri.Where(ic => ic.Curs.NumeCurs.Contains(searchString) || ic.Curs.Profesor.Nume.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    cursuri = cursuri.OrderBy(ic => ic.Curs.NumeCurs);
                    break;
                case "grade":
                    cursuri = cursuri.OrderByDescending(ic => ic.Nota);
                    break;
                default:
                    cursuri = cursuri.OrderBy(ic => ic.Curs.NumeCurs);
                    break;
            }

            // Gruparea cursurilor pe ani universitari
            var cursuriPeAni = cursuri
                .GroupBy(ic => ic.Curs.AnUniversitar)
                .Select(g => new CursuriPeAnViewModel
                {
                    AnUniversitar = g.Key,
                    Cursuri = g.ToList()
                }).ToList();

            return View(cursuriPeAni);
        }

        public async Task<IActionResult> Note(string sortOrder)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var student = await _context.Students
                .Include(s => s.UserAccount)
                .Include(s => s.InscrieriCursuri)
                .ThenInclude(ic => ic.Curs)
                .FirstOrDefaultAsync(s => s.UserAccount.Email == userId);

            if (student == null || student.InscrieriCursuri == null)
            {
                return NotFound();
            }

            var inscrieri = student.InscrieriCursuri.AsQueryable();

            ViewBag.CurrentSort = sortOrder;
            switch (sortOrder)
            {
                case "name":
                    inscrieri = inscrieri.OrderBy(ic => ic.Curs.NumeCurs);
                    break;
                case "grade":
                    inscrieri = inscrieri.OrderByDescending(ic => ic.Nota);
                    break;
                default:
                    inscrieri = inscrieri.OrderBy(ic => ic.Curs.NumeCurs);
                    break;
            }

            var notePeAni = inscrieri
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
