using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using BLLS;
using Domain.Entities;
using APIStackForum.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO.Responses;
using System.Net;

namespace UnitTests
{
    public class ForumControllerTest
    {
        [Fact]
        public async void GetSubjectsShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            DateTime dttime = DateTime.Now;

            List<Subject> subjects = new List<Subject>();

            subjects.Add(new Subject { Id = 1, CreationDate = dttime, categoryId = 1, Description = "Description 1 Lorem ipsum", Name = "Name1 Lorem" });
            subjects.Add(new Subject { Id = 2, CreationDate = dttime, categoryId = 2, Description = "Description 2 Lorem ipsum", Name = "Name2 Lorem" });
            subjects.Add(new Subject { Id = 3, CreationDate = dttime, categoryId = 3, Description = "Description 13Lorem ipsum", Name = "Name3 Lorem" });

            List<SubjectResponseDTO> subjectsResponseDTO = new List<SubjectResponseDTO>();

            subjectsResponseDTO.Add(new SubjectResponseDTO { Id = 1, CreationDate = dttime, CategoryId = 1, Description = "Description 1 Lorem ipsum", Name = "Name1 Lorem" });
            subjectsResponseDTO.Add(new SubjectResponseDTO { Id = 2, CreationDate = dttime, CategoryId = 2, Description = "Description 2 Lorem ipsum", Name = "Name2 Lorem" });
            subjectsResponseDTO.Add(new SubjectResponseDTO { Id = 3, CreationDate = dttime, CategoryId = 3, Description = "Description 13Lorem ipsum", Name = "Name3 Lorem" });


            Mock.Get(forumService)
                .Setup(f => f.GetSubjectsAsync())
                .ReturnsAsync(subjects);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult OkResult = await fc.GetSubjectsAsync();

            //Assert

            OkObjectResult OkRslt = OkResult as OkObjectResult;

            Assert.NotNull(OkRslt);
            Assert.Equal(subjectsResponseDTO, OkRslt.Value);

            

        }

        [Fact]

        public async void GetSubjectByIdShouldBeNotFound()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            Mock.Get(forumService)
                .Setup(f => f.GetSubjectByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(null as Subject);


            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult notFoundResult = await fc.GetSubjectByIdAsync(1);

            NotFoundResult nfres = notFoundResult as NotFoundResult;

            Assert.NotNull(nfres);
            


        }

        [Fact]
        public async void GetSubjectByIdShouldBeOk()
        {
            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            DateTime dttime = DateTime.Now;

            Subject subject = new Subject()
            {
                Id = 1,
                CreationDate = dttime,
                categoryId = 1,
                Description = "Description 1 Lorem ipsum",
                Name = "Name1 Lorem"

            };

            SubjectResponseDTO srdto = new SubjectResponseDTO
            {
                Id = 1,
                CreationDate = dttime,
                CategoryId = 1,
                Description = "Description 1 Lorem ipsum",
                Name = "Name1 Lorem"
            };

            Mock.Get(forumService)
                .Setup(f => f.GetSubjectByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(subject);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult Okrslt = await fc.GetSubjectByIdAsync(1);

            //Assert

            OkObjectResult OkResult = Okrslt as OkObjectResult;
            Assert.NotNull(OkResult);


        }

       [Fact]
       public async void GetAnswersBySubjectIdShouldBeNotFound()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            Mock.Get(forumService)
                .Setup(f => f.GetAnswersBySubjectIdAsync(It.IsAny<int>()))
                .ReturnsAsync(null as IEnumerable<Answer>);

            ForumController fc = new ForumController(forumService);


            //Act
            IActionResult nfrslt = await fc.GetAnswersBySubjectIdAsync(1);

            NotFoundResult notFoundResult = nfrslt as NotFoundResult;

            //Assert
            Assert.NotNull(notFoundResult);



        }

    }
}
