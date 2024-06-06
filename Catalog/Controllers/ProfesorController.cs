using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Controllers;

[Authorize(Roles = "Profesor")]
public class ProfesorController : Controller
{
    private readonly CatalogContext _context;

    public ProfesorController(CatalogContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.Name);
        var profesor = await _context.Profesori
            .Include(p => p.UserAccount)
            .FirstOrDefaultAsync(p => p.UserAccount.Email == userId);

        if (profesor == null)
        {
            return NotFound();
        }

        return View(profesor);
    }

    public async Task<IActionResult> Note()
    {
        var userId = User.FindFirstValue(ClaimTypes.Name);
        var profesor = await _context.Profesori
            .Include(p => p.UserAccount)
            .Include(p => p.Cursuri)
            .ThenInclude(c => c.InscrieriCursuri)
            .ThenInclude(ic => ic.Student)
            .FirstOrDefaultAsync(p => p.UserAccount.Email == userId);

        if (profesor == null)
        {
            return NotFound();
        }

        var inscrieri = profesor.Cursuri.SelectMany(c => c.InscrieriCursuri).ToList();
        return View(inscrieri);
    }

    [HttpPost]
    public async Task<IActionResult> AdaugaNota(int studentId, int cursId, decimal nota)
    {
        var inscriere = await _context.InscrieriCursuri.FirstOrDefaultAsync(ic => ic.StudentID == studentId && ic.CursID == cursId);
        if (inscriere != null)
        {
            inscriere.Nota = nota;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Note));
    }

}
