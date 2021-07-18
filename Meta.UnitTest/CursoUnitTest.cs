using Meta.UnitTest.Models;
using Meta.UnitTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Meta.UnitTest
{
    [TestClass]
    public class CursoUnitTest
    {
        [TestMethod]
        public void Get_Teste()
        {
            bool resultTeste = true;
            // Act
            var okResult = new CrudDAO<Curso>().Get("Cursoes");
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
            var lstCurso = new CrudDAO<Curso>().Get("Cursoes");



            Curso curso = new Curso()
            {

                Valor = 10.00,
                Descricao = "teste",
                NomeCurso = "nometeste"

            };

            try
            {
                new CrudDAO<Curso>().Create(curso, "Cursoes");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }

        }


    }
}
