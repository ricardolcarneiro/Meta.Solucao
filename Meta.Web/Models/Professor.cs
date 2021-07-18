//-----------------------------------------------------------------------
// <copyright file="Professor.cs" company="Meta">
//     Copyright (c) Meta. All rights reserved.
// </copyright>
// <author> Ricardo Carneiro</author>
//-----------------------------------------------------------------------

namespace Meta.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Classe da entidade Professor - Value Object
    /// </summary>
    public class Professor 
    {
        /// <summary>
        /// Idendificador id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do professor 
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento do professor
        /// </summary>
        public DateTime DataNascimento { get; set; }


        /// <summary>
        /// Identificador do Materia
        /// </summary>
        public int IdMateria { get; set; }

        /// <summary>
        /// Objeto da Materia
        /// </summary>
        public List<Materia> MateriaModel { get; set; }

    }
}
