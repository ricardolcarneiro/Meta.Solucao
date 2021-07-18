// -----------------------------------------------------------------------
// <copyright file="ProfessorsController.cs" company="Meta">
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
    public class ProfessorsController : Controller
    {
        private readonly AppDbContext _context;

        public ProfessorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Professors
        public async Task<IActionResult> Index()
        {

            return View(new CrudDAO<Professor>().Get("Professors"));
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Professor = new CrudDAO<Professor>().GetById(id, "Professors");
            if (Professor == null)
            {
                return NotFound();
            }

            return View(Professor);
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            var materia = new CrudDAO<Materia>().Get("Materias");
            Professor professor = new Professor();
            professor.MateriaModel = new List<Materia>();
            professor.MateriaModel = materia.ToList<Materia>();
            return View(professor);
        }

        // POST: Professors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,IdMateria")] Professor Professor)
        {
            if (ModelState.IsValid)
            {
                new CrudDAO<Professor>().Create(Professor, "Professors");

                return RedirectToAction(nameof(Index));
            }
            return View(Professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Professor = new CrudDAO<Professor>().GetById(id, "Professors");
            if (Professor == null)
            {
                return NotFound();
            }
            return View(Professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,IdMateria")] Professor Professor)
        {
            if (id != Professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Professor);
                    new CrudDAO<Professor>().Update(id, Professor, "Professors");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(Professor.Id))
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
            return View(Professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Professor = new CrudDAO<Professor>().GetById(id, "Professors");
            if (Professor == null)
            {
                return NotFound();
            }

            return View(Professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Professor = new CrudDAO<Professor>().GetById(id , "Professors");

            new CrudDAO<Professor>().Delete(id, "Professors");
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return new CrudDAO<Professor>().GetByIdExist(id, "Professors");
           
        }
    }
}
