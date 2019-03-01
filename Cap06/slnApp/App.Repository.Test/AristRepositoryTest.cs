using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using App.DataAccess.Repository.Interface;
using App.DataAccess.Repository;


namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void Count()
        {
            IArtistRepository repository = new ArtistRepository();
            int count = repository.Count();

            Assert.IsTrue(count > 0);

        }


        [TestMethod]
        public void GetAll()
        {
            IArtistRepository repository = new ArtistRepository();
            var data = repository.GetAll();

            Assert.IsTrue(data.Count() > 0);

        }


    }
}
