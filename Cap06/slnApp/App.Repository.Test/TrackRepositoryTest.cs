using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using App.DataAccess.Repository.Interface;
using App.DataAccess.Repository;
using System.Data.Entity;

namespace App.Repository.Test
{
    [TestClass]
    public class TrackRepositoryTest
    {
        private readonly DbContext _context;

        public TrackRepositoryTest()
        {
            _context = new AppDataModel();
        }



        public void GetAll()
        {
            ITrackRepository repository = new TrackRepository(_context);
            var entities = repository.GetTrackAlls("%AERO");

            Assert.IsTrue(repository.Count() > 0);
        }



    }

}
