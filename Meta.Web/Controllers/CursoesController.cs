// -----------------------------------------------------------------------
// <copyright file="CursoesController.cs" company="Meta">
//     Copyright (c) Meta All rights reserved.
// </copyright>
// <author> Ricardo Carneiro</author>
//-----------------------------------------------------------------------

namespace Meta.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Meta.Web.Models;
    using Meta.Web.Util;

    public class CursoesController : Controller
    {
        private readonly AppDbContext _context;

        public CursoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {

            return View(new CrudDAO<Curso>().Get("Cursoes"));
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Curso = new CrudDAO<Curso>().GetById(id, "Cursoes");
            if (Curso == null)
            {
                return NotFound();
            }

            return View(Curso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCurso,Valor,Descricao")] Curso Curso)
        {
            if (ModelState.IsValid)
            {
                new CrudDAO<Curso>().Create(Curso, "Cursoes");

                return RedirectToAction(nameof(Index));
            }
            return View(Curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Curso = new CrudDAO<Curso>().GetById(id, "Cursoes");
            if (Curso == null)
            {
                return NotFound();
            }
            return View(Curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCurso,Valor,Descricao")] Curso Curso)
        {
            if (id != Curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Curso);
                    new CrudDAO<Curso>().Update(id, Curso, "Cursoes");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(Curso.Id))
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
            return View(Curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Curso = new CrudDAO<Curso>().GetById(id, "Cursoes");
            if (Curso == null)
            {
                return NotFound();
            }

            return View(Curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Curso = new CrudDAO<Curso>().GetById(id, "Cursoes");

            new CrudDAO<Curso>().Delete(id, "Cursoes");
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return new CrudDAO<Curso>().GetByIdExist(id, "Cursoes");

        }
    }
}
