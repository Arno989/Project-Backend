using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using popcorn.DTO;
using popcorn.Models;
using Xunit;

namespace popcorn.test
{
    public class MovieControllerTest : IClassFixture<WebApplicationFactory<popcorn.Startup>>
    {
        public HttpClient Client { get; }

        public MovieControllerTest(WebApplicationFactory<popcorn.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        #region Actor
        [Fact]
        public async Task Get_Actors()
        {
            var response = await Client.GetAsync("/api/actors");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var actors = JsonConvert.DeserializeObject<List<ActorDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(actors.Count > 0);
        }
        [Fact]
        public async Task Get_Actor()
        {
            var response = await Client.GetAsync("/api/actors/nm0424060");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var actors = JsonConvert.DeserializeObject<List<ActorDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(actors.Count == 1);
        }

        [Fact]
        public async Task Add_Actor()
        {
            var actor = new ActorDTO()
            {
                IMDBActorId = "nm0001618",
                Name = "Joaquin Phoenix",
                Born = new DateTime(1974, 10, 28)
            };

            string json = JsonConvert.SerializeObject(actor);
            var response = await Client.PostAsync("/api/actors", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdActor = JsonConvert.DeserializeObject<ActorDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdActor);
        }
        #endregion

        #region Genre
        [Fact]
        public async Task Get_Genres()
        {
            var response = await Client.GetAsync("/api/genres");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var genres = JsonConvert.DeserializeObject<List<GenreDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(genres.Count > 0);
        }
        [Fact]
        public async Task Get_Genre()
        {
            var response = await Client.GetAsync("/api/genres/fa3599f5-af78-40f1-ab9c-c2921d40e02d");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var genres = JsonConvert.DeserializeObject<List<GenreDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(genres.Count == 1);
        }

        [Fact]
        public async Task Add_Genre()
        {
            var genre = new GenreDTO()
            {
                GenreId = Guid.NewGuid(),
                Name = "Romance"
            };

            string json = JsonConvert.SerializeObject(genre);
            var response = await Client.PostAsync("/api/genres", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdGenre = JsonConvert.DeserializeObject<GenreDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdGenre);
        }
        #endregion

        #region Movie
        [Fact]
        public async Task Get_Movies()
        {
            var response = await Client.GetAsync("/api/movies");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(movies.Count > 0);
        }
        [Fact]
        public async Task Get_Movie()
        {
            var response = await Client.GetAsync("/api/movies/tt2872732");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(movies.Count == 1);
        }

        [Fact]
        public async Task Add_Movie()
        {
            var movie = new MovieDTO()
            {
                IMDBMovieId = "tt1798709",
                Name = "Her",
                Runtime = 126,
                ReleaseDate = new DateTime(2013, 1, 10),
                Synopsis = "In a near future, a lonely writer develops an unlikely relationship with an operating system designed to meet his every need.",
                Rating = 8.0
            };

            string json = JsonConvert.SerializeObject(movie);
            var response = await Client.PostAsync("/api/movies", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdMovie = JsonConvert.DeserializeObject<MovieDTO>(await response.Content.ReadAsStringAsync()); 
            Assert.NotNull(createdMovie);
        }
        #endregion

        #region Torrent
        [Fact]
        public async Task Get_Torrents()
        {
            var response = await Client.GetAsync("/api/torrents");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var torrents = JsonConvert.DeserializeObject<List<TorrentDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(torrents.Count > 0);
        }
        [Fact]
        public async Task Get_Torrent()
        {
            var response = await Client.GetAsync("/api/torrents/tt1798709");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var torrents = JsonConvert.DeserializeObject<List<TorrentDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(torrents.Count == 1);
        }

        [Fact]
        public async Task Add_Torrent()
        {
            var torrent = new TorrentDTO()
            {
                TorrentId = Guid.NewGuid(),
                IMDBMovieId = "tt1798709",
                MagnetLink = "http://yts.ge/torrent/download/Her%20(2013)%20%5b1080p%5d%20%5bBluRay%5d%20%5bYTS.MX%5d.torrent",
                Quality = "1080p",
                Seeds = 85,
                Peers = 357,
                FileSize = "1.8Gb"
            };

            string json = JsonConvert.SerializeObject(torrent);
            var response = await Client.PostAsync("/api/torrents", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdTorrent = JsonConvert.DeserializeObject<TorrentDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdTorrent);
        }
        #endregion
    }
}
