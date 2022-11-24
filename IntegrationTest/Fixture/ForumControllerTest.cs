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


        [Fact]

        public async void GetAnswersBySubjectIdShouldBeOk()
        {
            //Arrange
            string uri = "api/forum/subjects/1/answers";

            AnswerResponseDTO ardto = new AnswerResponseDTO() {
                Id = 49,
                SubjectId = 1,
                Body = "ajout",
                CreationDate = new DateTime(2022,11,10,11,33,16),
                WriterId = 22
            };
            AnswerResponseDTO ardto2 = new AnswerResponseDTO()
            {
                Id = 50,
                SubjectId = 1,
                Body = "answer",
                CreationDate = new DateTime(2022,11,10,11,41,16),
                WriterId = 23
            };

            List<AnswerResponseDTO> listanswers = new List<AnswerResponseDTO>();

            listanswers.Add(ardto);
            listanswers.Add(ardto2);



            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            List<AnswerResponseDTO> listanswerresponse = await response.Content.ReadFromJsonAsync<List<AnswerResponseDTO>>();

            Assert.Equal(listanswers, listanswerresponse);

        }

        [Fact]

        public async void GetAnswersBySubjectIdShouldBeNotFound()
        {
            //Arrange
            string uri = "api/forum/subjects/99999999/answers";


            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NotFound);



        }

        [Fact]

        public async void GetSubjectsByCategoryShouldBeOk()
        {
            //Arrange

            string uri = "api/forum/categories/1/subjects";

            SubjectResponseDTO srdto = new SubjectResponseDTO()
            {
                Id = 1,
                Name = "subject999",
                Description = "description999",
                WriterId = 6,
                CategoryId = 1,
                CreationDate = new DateTime(2022, 10, 10, 15, 56, 39,257)//"2022-10-10T15:56:39.257"
            };

            List<SubjectResponseDTO> listsrdto = new List<SubjectResponseDTO>();
            listsrdto.Add(srdto);


            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            List<SubjectResponseDTO> listsrdtoexpected = await response.Content.ReadFromJsonAsync<List<SubjectResponseDTO>>();

            Assert.Equal(listsrdtoexpected, listsrdto);

        }

    }
}
