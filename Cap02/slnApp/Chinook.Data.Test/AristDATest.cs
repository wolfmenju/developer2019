using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void GetCountTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void GetArtistTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetArtists().Count > 0);

        }

        [TestMethod]
        public void GetArtistByNameTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetArtists("a%").Count > 0);

        }

        [TestMethod]
        public void InsertArtistTest()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtits(
            new Entities.Artist()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
            }

        [TestMethod]

        public void InsertArtiWithOutPutTest()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtitsWithOutPut(
            new Entities.Artist()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void InsertArtitsWithTX()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtitsWithTX(
            new Entities.Artist()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
        }
    }

         
    }

      
    

