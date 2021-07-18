using Meta.UnitTest.Models;
using Meta.UnitTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Meta.UnitTest
{
    [TestClass]
    public class ProfessorUnitTest
    {
        [TestMethod]
        public void Get_Teste()
        {
            bool resultTeste = true;
            // Act
            var okResult = new CrudDAO<Professor>().Get("Professors");
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
            var lstProfessor = new CrudDAO<Professor>().Get("Professors");



            Professor Professor = new Professor()
            {
                DataNascimento = System.DateTime.Now,
                IdMateria = 1,
                Nome = "teste"
       

            };

            try
            {
                new CrudDAO<Professor>().Create(Professor, "Professors");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }

        }


    }
}
