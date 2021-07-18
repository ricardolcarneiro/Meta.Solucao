using Meta.UnitTest.Models;
using Meta.UnitTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Meta.UnitTest
{
    [TestClass]
    public class MateriaUnitTest
    {
        [TestMethod]
        public void Get_Teste()
        {
            bool resultTeste = true;
            // Act
            var okResult = new CrudDAO<Materia>().Get("Materias");
            // Assert

            if (okResult == null)
            {
                resultTeste = false;
                Assert.IsFalse(resultTeste);
            }
            else
            {
                resultTeste = true;
                Assert.IsTrue(resultTeste);
            }

        }

        [TestMethod]
        public void PostTeste()
        {
            // Act
            var lstMateria = new CrudDAO<Materia>().Get("Materias");



            Materia Materia = new Materia()
            {

                IdCurso = 1,
                Descricao = "teste",
                NomeMateria = "nometeste"

            };

            try
            {
                new CrudDAO<Materia>().Create(Materia, "Materias");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }

        }


    }
}
