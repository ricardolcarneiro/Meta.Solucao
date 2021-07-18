//-----------------------------------------------------------------------
// <copyright file="Materia.cs" company="Meta">
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
    /// Classe da entidade Materia - Value Object
    /// </summary>
    public class Materia
    {
        /// <summary>
        /// Idendificador id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Materia 
        /// </summary>
        public string NomeMateria { get; set; }

        /// <summary>
        /// Descricao do Materia
        /// </summary>
        public string Descricao { get; set; }


        /// <summary>
        /// Identificador do Curso
        /// </summary>
        public int IdCurso { get; set; }

        /// <summary>
        /// Objeto do Curso
        /// </summary>
        public List<Curso> CursoModel { get; set; }




    }
}
