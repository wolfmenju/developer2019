using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using App.DataAccess.Repository.Interface;
using App.DataAccess.Repository;
using System.Data.Entity;

namespace App.EF.CodeFirst.Test
{

    [TestClass]
    public class TrackRepositoryTest
    {
        private readonly DbContext _context;

        public TrackRepositoryTest()
        {
            _context = new AppDataModel();
        }

        [TestMethod]
        public void Count()
        {
        //    IArtistRepository repository = new ArtistRepository();
        //    int count = repository.Count();

        //    Assert.IsTrue(count > 0);

        }


        [TestMethod]
        public void GetAll()
        {
            //IArtistRepository repository = new ArtistRepository();
            //var data = repository.GetAll(item => item.Name.Contains("Artist"),
            //    item => item.OrderBy(item2 => item2.Name));

            //Assert.IsTrue(data.Count() > 0);

        }




    }
}
