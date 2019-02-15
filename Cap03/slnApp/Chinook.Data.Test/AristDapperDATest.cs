using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDADapperTest
    {
        [TestMethod]
        public void GetCountTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetCountDapper() > 0);

        }

        [TestMethod]
        public void GetArtistTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtists().Count > 0);

        }

        [TestMethod]
        public void GetArtistByNameTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtists("a%").Count > 0);

        }

        [TestMethod]
        public void GetArtistByNameSPTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtistsWithSP("a%").Count > 0);

        }

        [TestMethod]
        public void InsertArtistDapperTest()
        {
            var da = new ArtistDapperDA();
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
            var da = new ArtistDapperDA();
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
            var da = new ArtistDapperDA();
            var nuevoArtista = da.InsertArtitsWithTX(
            new Entities.Artist()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void InsertArtitsWithTXDsitrTex()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtitsWithTXDsitr(
            new Entities.Artist()
            {
                Name = "Nuevo Artista" + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(nuevoArtista > 0);
        }
    }

         
    }

      
    

