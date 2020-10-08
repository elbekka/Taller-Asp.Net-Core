using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Models;
using Infrastructure.Programmers;
using System.Threading;
using Infrastructure.ProgrammerType;

namespace WebApp.Controllers
{
    public class ProgramadorsController : Controller
    {
        private readonly GestorContext _context;
        private readonly IProgrammerRespository _programmerRespository;
        private readonly IProgrammerType _programmerType;

        public ProgramadorsController(GestorContext context,IProgrammerRespository programmerRespository,IProgrammerType programmerType)
        {
            _context = context;
            _programmerRespository = programmerRespository;
            _programmerType = programmerType;
        }

        // GET: Programadors
        public async Task<IActionResult> Index()
        {
            
            return View(await _programmerRespository.GetAllProgrammers(default));
        }

        // GET: Programadors/Details/5
        public async Task<IActionResult> Details(int? id,CancellationToken cancellationToken)
        {
            var programador = await _programmerRespository.GetProgrammerById(id, cancellationToken);
            if (programador == null) return NotFound();
            return View(programador);
        }

        // GET: Programadors/Create
        public async Task<IActionResult> Create()
        {
            var list = await _programmerType.GetSelectList(default);
            ViewData["TipoProgramadorId"] = new SelectList(list.Item1,list.Item2,list.Item3);
            return View();
        }

        // POST: Programadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoProgramadorId,Nombre,Apellido,Edad,DNI_NIE")] Programador programador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProgramadorId"] = new SelectList(_context.TipoProgramadores, "Id", "Nombre", programador.TipoProgramadorId);
            return View(programador);
        }

        // GET: Programadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = await _context.Programadores.FindAsync(id);
            if (programador == null)
            {
                return NotFound();
            }
            ViewData["TipoProgramadorId"] = new SelectList(_context.TipoProgramadores, "Id", "Nombre", programador.TipoProgramadorId);
            return View(programador);
        }

        // POST: Programadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoProgramadorId,Nombre,Apellido,Edad,DNI_NIE")] Programador programador)
        {
            if (id != programador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramadorExists(programador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProgramadorId"] = new SelectList(_context.TipoProgramadores, "Id", "Nombre", programador.TipoProgramadorId);
            return View(programador);
        }

        // GET: Programadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = await _context.Programadores
                .Include(p => p.TipoProgramador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programador == null)
            {
                return NotFound();
            }

            return View(programador);
        }

        // POST: Programadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programador = await _context.Programadores.FindAsync(id);
            _context.Programadores.Remove(programador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramadorExists(int id)
        {
            return _context.Programadores.Any(e => e.Id == id);
        }
    }
}
