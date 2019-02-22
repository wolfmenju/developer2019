using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class AlbumDADapperTest
    {
        [TestMethod]
        public void GetCountTest()
        {
            var da = new AlbumDapperDA();

            Assert.IsTrue(da.GetAlbumCountDapper() > 0);

        }


        [TestMethod]
        public void GetListaSPTest()
        {
            var da = new AlbumDapperDA();

            Assert.IsTrue(da.GetAlbumSP("a%").Count > 0);

        }


        [TestMethod]
        public void InsertAlbumSPTest()
        {
            var da = new AlbumDapperDA();

            var nuevoAlbum = da.InsertAlbum
            (new Entities.Album()

            {
                Title = "nue" + Guid.NewGuid().ToString(),
                ArtistId = Convert.ToInt32("23")
            }
               
       
            );

            Assert.IsTrue(nuevoAlbum > 0);
        }

        [TestMethod]
        public void UpdateAlbumSPTest()
        {
            var da = new AlbumDapperDA();

            var ActualizarAlbum = da.UpdateAlbum
            (new Entities.Album()

            {
                Title ="JULIO GOMEZ",
                AlbumId = Convert.ToInt32("24")
            }


            );

            Assert.IsTrue(ActualizarAlbum==true);
        }


        [TestMethod]
        public void DeleteAlbumSPTest()
        {
            var da = new AlbumDapperDA();

            var ActualizarAlbum = da.DeleteAlbumSP
            (new Entities.Album()

            { 
                AlbumId = Convert.ToInt32("24")
            }


            );

            Assert.IsTrue(ActualizarAlbum > 0);
        }

    }


}

      
    

