//---------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Meta">
//     Copyright (c) Meta. All rights reserved.
// </copyright>
// <author> Ricardo Carneiro</author>
//-----------------------------------------------------------------------
namespace Meta.API.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// Classe de context do aplicação
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Construtor com  AppDbContext 
        /// </summary>
        /// <param name="dbContextOptions">Paramentro opções do contexto</param>
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        /// <summary>
        /// Encapsulamento Db Set Cursos
        /// </summary>
        public DbSet<Curso> Cursos { get; set; }
        /// <summary>
        /// Encapsulamento Db Set Materias
        /// </summary>
        public DbSet<Materia> Materias { get; set; }
        /// <summary>
        /// Encapsulamento Db Set Professores
        /// </summary>
        public DbSet<Professor> Professores { get; set; }

    }
}
