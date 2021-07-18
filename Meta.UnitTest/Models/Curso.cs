//-----------------------------------------------------------------------
// <copyright file="Curso.cs" company="Meta">
//     Copyright (c) Meta. All rights reserved.
// </copyright>
// <author> Ricardo Carneiro</author>
//-----------------------------------------------------------------------

namespace Meta.UnitTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Classe da entidade Curso - Value Object
    /// </summary>
    public class Curso
    {
        /// <summary>
        /// Idendificador id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do curso 
        /// </summary>
        public string NomeCurso { get; set; }

        /// <summary>
        /// Valor do Curso
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// Descricao do curso
        /// </summary>
        public string Descricao { get; set; }
    }
}
