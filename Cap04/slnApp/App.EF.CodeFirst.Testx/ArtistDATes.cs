using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.EF.CodeFirst.Testx
{
    [TestClass]
    public class ArtistDATes
    {
        [TestMethod]
        public void GetArtistCount()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.Count()> 0);
         }

        [TestMethod]
        public void Insetr()
        {
            var da = new ArtistDA();
            var id = da.Insert(
                new Artist()
                {
                    Name = "Artist"
                    + Guid.NewGuid().ToString()

                });

            Assert.IsTrue(da.Count() > 0);
        }

        [TestMethod]
        public void Delete()
        {
            var list = new List<int>();

            list.Add(287);
            list.Add(289);
            list.Add(290);
            list.Add(291);

            var da = new ArtistDA();

            Assert.IsTrue(da.DeleteBach(list));
        }



    }
}
