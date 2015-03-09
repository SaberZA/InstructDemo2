using System;
using System.Threading.Tasks;
using Instruct2.Core;
using NUnit.Framework;

namespace Instruct2.Test
{
    [TestFixture]
    public class MovieServiceIntegrationTest
    {
        private string localAddress = "http://192.168.1.105:1337";

        [Test]
        public async void GetTop100MoviesOfAllTime_GivenMovieService_ShouldReturn100Movies()
        {
            //---------------Set up test pack-------------------
            var movieService = new MovieService(localAddress);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var movieList = await movieService.GetTop100MoviesOfAllTime();
            //---------------Test Result -----------------------
            Assert.AreEqual(100, movieList.Movies.Count);
        }

    }
}
