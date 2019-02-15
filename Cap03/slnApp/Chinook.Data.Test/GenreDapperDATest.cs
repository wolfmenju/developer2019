﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    /// <summary>
    /// Descripción resumida de GenreDATest
    /// </summary>
    [TestClass]
    public class GenreDapperDATest
    {
        public GenreDapperDATest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetGenreWithSPTest()
        {
            var da = new GenereDapperDA();

            Assert.IsTrue(da.GetGenreWithSP("a%").Count > 0);
        }

        [TestMethod]
        public void InsertGenreTest()
        {
            var da = new GenereDapperDA();
            var nuevoArtista = da.InsertGenre(
            new Entities.Genre()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void UpdateGenreTest()
        {
            var da = new GenereDapperDA();
            var nuevoGene = da.UpdateGenre(
            new Entities.Genre()
            {
                Name = "Actualiza" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(da.UpdateGenre());
        }
    }
}