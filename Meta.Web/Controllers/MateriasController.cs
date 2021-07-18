// -----------------------------------------------------------------------
// <copyright file="MateriasController.cs" company="Meta">
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
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {

            return View(new CrudDAO<Materia>().Get("Materias"));
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Materia = new CrudDAO<Materia>().GetById(id, "Materias");
            if (Materia == null)
            {
                return NotFound();
            }

            return View(Materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            var Curso = new CrudDAO<Curso>().Get("Cursoes");
            Materia materia = new Materia();
            materia.CursoModel = new List<Curso>();
            materia.CursoModel = Curso.ToList<Curso>();
        
            return View(materia);
        }

        private void bindDropDownList()
        {
            var Curso = new CrudDAO<Curso>().Get("Cursoes");
            ViewBag.Curso = new SelectList
          (
              Curso,
              "Id",
              "NomeCurso"
          );
      
          
        }
        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeMateria,Descricao,IdCurso")] Materia Materia)
        {
            if (ModelState.IsValid)
            {
                new CrudDAO<Materia>().Create(Materia, "Materias");

                return RedirectToAction(nameof(Index));
            }
            return View(Materia);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Materia = new CrudDAO<Materia>().GetById(id, "Materias");
            if (Materia == null)
            {
                return NotFound();
            }
            return View(Materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeMateria,Descricao,IdCurso")] Materia Materia)
        {
            if (id != Materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Materia);
                    new CrudDAO<Materia>().Update(id, Materia, "Materias");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(Materia.Id))
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
            return View(Materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Materia = new CrudDAO<Materia>().GetById(id, "Materias");
            if (Materia == null)
            {
                return NotFound();
            }

            return View(Materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Materia = new CrudDAO<Materia>().GetById(id, "Materias");

            new CrudDAO<Materia>().Delete(id, "Materias");
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return new CrudDAO<Materia>().GetByIdExist(id, "Materias");

        }
    }
}
