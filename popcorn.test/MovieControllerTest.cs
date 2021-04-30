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


        [Fact]
        public async Task Get_Movies()
        {
            var response = await Client.GetAsync("/api/movies");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(movies.Count > 0);
        }

        [Fact]
        public async Task Add_Movies()
        {
            var movie = new MovieDTO()
            {
                IMDBMovieId = "",
                Name = "",
                Runtime = 120,
                ReleaseDate = new DateTime(1999, 10, 28),
                Synopsis = "",
                Genres = new List<String>{"Action", "Sci-Fi"},
                Rating = 3.5,
                Actors = new List<Actor>{new Actor{IMDBActorId  = "", Name = "", Age = 50, Movies = new List<Movie>{}}},
                Torrents = new List<Torrent>{new Torrent{Id = new Guid{}, IMDBMovieId  = "", MagnetLink = "", Quality = "", Seeds = 10, Peers = 10, FileSize = "6Gb" }}
            };

            string json = JsonConvert.SerializeObject(movie);
            var response = await Client.PostAsync("/api/movies", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdMovie = JsonConvert.DeserializeObject<MovieDTO>(await response.Content.ReadAsStringAsync()); 
            Assert.NotNull(createdMovie);
        }
    }
}
