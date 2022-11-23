using Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Fixture
{
   public class ForumControllerTest : AbstractIntegrationTest
    {

        public ForumControllerTest(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Fact]
        public async void GetSubjectByIdShouldBeOk()
        {
            //Arrange
            string uri = "api/forum/subjects/1";

            SubjectResponseDTO srdtoexpected = new SubjectResponseDTO()
            {
                Id = 1,
                Name = "subject999",
                CategoryId = 1,
                CreationDate = new DateTime(638010141992570000),
                Description = "description999",
                WriterId = 6
            };

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            SubjectResponseDTO srdto = await response.Content.ReadFromJsonAsync<SubjectResponseDTO>();

            Assert.Equal(srdtoexpected, srdto);
        }

        [Fact]

        public async void GetSubjectByIdShouldBeNotFound()
        {
            string uri = "api/forum/subjects/999999999";

            
            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

    }
}
