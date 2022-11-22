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
using Domain.DTO.Requests;
using APIStackForum;
using Domain.Exceptions;

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

        [Fact]
        public async void GetAnswersBySubjectIdShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            DateTime dttime = DateTime.Now;

            Answer answer1 = new Answer()
            {
                Id = 1,
                CreationDate = dttime,
                Body = "Lorem",
                subjectId = 1,
                writerId = 1

            };
            Answer answer2 = new Answer()
            {
                Id = 2,
                CreationDate = dttime,
                Body = "Ipsum",
                subjectId = 1,
                writerId = 2

            };

            List<Answer> answers = new List<Answer>();
            answers.Add(answer1);
            answers.Add(answer2);

            Mock.Get(forumService)
                .Setup(f => f.GetAnswersBySubjectIdAsync(It.IsAny<int>()))
                .ReturnsAsync(answers);

            ForumController fc = new ForumController(forumService);
            //Act

            IActionResult result = await fc.GetAnswersBySubjectIdAsync(1);

            //Assert

            OkObjectResult Okresult = result as OkObjectResult;
            Assert.NotNull(Okresult);

        }

        [Fact]
        public async void GetSubjectsByCategoryIdShouldBeNotFound()
        {
            //Arrange
            IForumService forumService = Mock.Of<IForumService>();

            Mock.Get(forumService)
                .Setup(f => f.GetSubjectsByCategoryId(It.IsAny<int>()))
                .ReturnsAsync(null as IEnumerable<Subject>);

            ForumController fc = new ForumController(forumService);

            //Act
            IActionResult nf = await fc.GetSubjectsByCategoryIdAsync(1);

            //Assert
            NotFoundResult notfoundres = nf as NotFoundResult;
            Assert.NotNull(notfoundres);

        }

        [Fact]
        public async void GetSubjectByCategoryIdShouldBeOk()
        {
            // Arrange
            IForumService forumService = Mock.Of<IForumService>();
            DateTime dttime = DateTime.Now;

            List<Subject> subjects = new List<Subject>();

            Subject subject1 = new Subject()
            {
                Id = 1,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

             Subject subject2 = new Subject()
             {
                 Id = 1,
                 Name = "Lorem2",
                 categoryId = 1,
                 CreationDate = dttime,
                 Description = "Ipsum2",
                 writerId = 2

             };

             subjects.Add(subject1);
            subjects.Add(subject2);




            Mock.Get(forumService)
                .Setup(f => f.GetSubjectsByCategoryId(It.IsAny<int>()))
                .ReturnsAsync(subjects);

            ForumController fc = new ForumController(forumService);

            //Act
            IActionResult foundresult = await fc.GetSubjectsByCategoryIdAsync(1);

            //Assert
            OkObjectResult foundres = foundresult as OkObjectResult;
            Assert.NotNull(foundres);


        }

        [Fact]
        public async void CreateSubjectShouldBeBadRequest()
        {
            // Arrange
            IForumService forumService = Mock.Of<IForumService>();
            DateTime dttime = DateTime.Now;

            Subject subject1 = new Subject()
            {
                Id = 1,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

            CreateSubjectRequestDTO csbjrdto = new CreateSubjectRequestDTO()
            {
                CategoryId = 1,
                Name = "Loremdr",
                Description = "Ipsumdr",
                WriterId = 1

            }; 

            


            Mock.Get(forumService)
                .Setup(f => f.CreateSubjectAsync(subject1))
                .ReturnsAsync(null as Subject);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult badrequest = await fc.CreateSubjectAsync(csbjrdto);

            //Assert
            BadRequestResult badr = badrequest as BadRequestResult;
            Assert.NotNull(badr);
        }

        [Fact]

        public async void CreateSubjectShouldBeOk()
        {

            //Arrange 

            IForumService forumService = Mock.Of<IForumService>();

            ForumController fc = new ForumController(forumService);

            DateTime dttime = DateTime.Now;

            Subject subject1 = new Subject()
            {
                Id =0,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

            CreateSubjectRequestDTO csbjrdto = new CreateSubjectRequestDTO()
            {
                CategoryId = 1,
                Name = "Loremdr",
                Description = "Ipsumdr",
                WriterId = 1

            };


            Mock.Get(forumService)
                .Setup(f => f.CreateSubjectAsync(subject1))
                .ReturnsAsync(subject1);

            //Act

            IActionResult Okresult = await fc.CreateSubjectAsync(csbjrdto);

            //Assert

            CreatedAtActionResult Okres = Okresult as CreatedAtActionResult;

            Assert.NotNull(Okres);


        }

        [Fact]

        public async void ModifySubjectShouldBeBadRequest()
        {

            IForumService forumService = Mock.Of<IForumService>();
            DateTime dttime = DateTime.Now;

            Subject subject1 = new Subject()
            {
                Id = 1,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

            ModifySubjectRequestDTO msbjrdto = new ModifySubjectRequestDTO()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Loremdr",
                Description = "Ipsumdr",
                writerId = 1
            };




            Mock.Get(forumService)
                .Setup(f => f.ModifySubjectAsync(subject1))
                .ReturnsAsync(null as Subject);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult badrequest = await fc.ModifySubjectAsync(2,msbjrdto);

            //Assert
            BadRequestResult badr = badrequest as BadRequestResult;
            Assert.NotNull(badr);
        }

        [Fact]

        public async void ModifySubjectShouldBeNotFound()
        {


            IForumService forumService = Mock.Of<IForumService>();
            DateTime dttime = DateTime.Now;

            Subject subject1 = new Subject()
            {
                Id = 1,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

            ModifySubjectRequestDTO msbjrdto = new ModifySubjectRequestDTO()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Loremdr",
                Description = "Ipsumdr",
                writerId = 1
            };




            Mock.Get(forumService)
                .Setup(f => f.ModifySubjectAsync(subject1))
                .ReturnsAsync(null as Subject);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult notFoundResult = await fc.ModifySubjectAsync(1, msbjrdto);

            //Assert
            NotFoundResult Notf = notFoundResult as NotFoundResult;
            Assert.NotNull(Notf);

        }

        [Fact]

        public async void ModifySubjectShouldBeOk()
        {

            IForumService forumService = Mock.Of<IForumService>();
            DateTime dttime = DateTime.Now;

            Subject subject1 = new Subject()
            {
                Id = 1,
                Name = "Lorem",
                categoryId = 1,
                CreationDate = dttime,
                Description = "Ipsum",
                writerId = 1

            };

            ModifySubjectRequestDTO msbjrdto = new ModifySubjectRequestDTO()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Loremdr",
                Description = "Ipsumdr",
                writerId = 1
            };




            Mock.Get(forumService)
                .Setup(f => f.ModifySubjectAsync(subject1))
                .ReturnsAsync(subject1);

            ForumController fc = new ForumController(forumService);

            //Act

            IActionResult OKresult = await fc.ModifySubjectAsync(1, msbjrdto);

            //Assert
            OkObjectResult okres = OKresult as OkObjectResult;
            Assert.NotNull(okres);
        }
        
    [Fact]
    public async void DeleteSubjectShouldThrowInvalidUserRequestException()
        {
           
            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Subject enquiredSubject = new Subject()
            {
                Id = 1,
                categoryId = 1,
                CreationDate = dttime,
                Description = "Description1",
                Name = "Name1",
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetSubjectByIdAsync(It.IsAny<int>()))
             .ReturnsAsync(enquiredSubject);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(2);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(false);


            //Asserts et Act

            await Assert.ThrowsAsync<InvalidUserRequestException>(() => fc.DeleteSubjectAsync(1));



        }


     [Fact]
     public async void DeleteSubjectShouldBeNoContent()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Subject enquiredSubject = new Subject()
            {
                Id = 1,
                categoryId = 1,
                CreationDate = dttime,
                Description = "Description1",
                Name = "Name1",
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetSubjectByIdAsync(1))
             .ReturnsAsync(enquiredSubject);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(1);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(true);

            Mock.Get(forumService)
                .Setup(f => f.DeleteSubjectAsync(1))
                .ReturnsAsync(true);


            //Act

            IActionResult NoContentRes = await fc.DeleteSubjectAsync(1);

            //Assert

            NoContentResult nocontent = NoContentRes as NoContentResult;
            Assert.NotNull(nocontent);
            
            
            
 

        }

        [Fact]
        public async void DeleteSubjectShouldBeNotFound()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Subject enquiredSubject = new Subject()
            {
                Id = 1,
                categoryId = 1,
                CreationDate = dttime,
                Description = "Description1",
                Name = "Name1",
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetSubjectByIdAsync(1))
             .ReturnsAsync(null as Subject);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(1);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(true);

            Mock.Get(forumService)
                .Setup(f => f.DeleteSubjectAsync(1))
                .ReturnsAsync(false);


            //Act

            IActionResult notfoundres = await fc.DeleteSubjectAsync(1);

            //Assert

            NotFoundResult notf = notfoundres as NotFoundResult;
            Assert.NotNull(notf);





        }

        [Fact]

     public async void GetAnswersShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);

            DateTime dttime = DateTime.Now;

            List<Answer> answers = new List<Answer>();

            answers.Add(new Answer { Id = 1, Body = "body1", CreationDate = dttime, subjectId = 1, writerId = 1 });
            answers.Add(new Answer { Id = 2, Body = "body2", CreationDate = dttime, subjectId = 1, writerId = 2 });
            answers.Add(new Answer { Id = 3, Body = "body3", CreationDate = dttime, subjectId = 1, writerId = 1 });



            Mock.Get(forumService)
                .Setup(f => f.GetAnswersAsync())
                .ReturnsAsync(answers);

            //Act

            IActionResult Okres = await fc.GetAnswersAsync();

            //Assert
            OkObjectResult okr = Okres as OkObjectResult;
            Assert.NotNull(okr);
        
        
        }

        [Fact]
        public async void GetAnswersByIdShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);

            DateTime dttime = DateTime.Now;

            Answer answer = new Answer() { Id = 1, Body = "Answer1", CreationDate = dttime, subjectId = 1, writerId = 1 };

            Mock.Get(forumService)
                .Setup(f => f.GetAnswerByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(answer);

            //Act

            IActionResult Okres = await fc.GetAnswerByIdAsync(1);

            //Assert

            OkObjectResult okr = Okres as OkObjectResult;
            Assert.NotNull(okr);
        }

        [Fact]
        public async void CreateAnswerShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);

            DateTime dttime = DateTime.Now;

            CreateAnswerRequestDTO cardto = new CreateAnswerRequestDTO
            {
                Body = "Answer1",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };

            Answer answer = new Answer() { Id = 0, Body = "Answer1", CreationDate = dttime, subjectId = 1, writerId = 1 };

            Mock.Get(forumService)
                .Setup(f => f.CreateAnswerAsync(answer))
                .ReturnsAsync(answer);

            //Act

            IActionResult Okresult = await fc.CreateAnswer(cardto);

            //Assert
            CreatedAtActionResult okres = Okresult as CreatedAtActionResult;
            Assert.NotNull(okres);

        }

        [Fact]
        public async void CreateAnswerShouldBeBadRequest()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);

            DateTime dttime = DateTime.Now;

            CreateAnswerRequestDTO cardto = new CreateAnswerRequestDTO
            {
                Body = "Answer1",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };

            Answer answer = new Answer() { Id = 1, Body = "Answer1", CreationDate = dttime, subjectId = 1, writerId = 1 };

            Mock.Get(forumService)
                .Setup(f => f.CreateAnswerAsync(answer))
                .ReturnsAsync(answer);

            //Act

            IActionResult Okresult = await fc.CreateAnswer(cardto);

            //Assert
            BadRequestResult okres = Okresult as BadRequestResult;
            Assert.NotNull(okres);

        }


        [Fact]

        public async void ModifyAnswerShouldBeBadRequest()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);
            DateTime dttime = DateTime.Now;

            Answer answer = new Answer()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };


            ModifyAnswerRequestDTO mardto = new ModifyAnswerRequestDTO()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };


            Mock.Get(forumService)
                .Setup(f => f.ModifyAnswerAsync(answer))
                .ReturnsAsync(null as Answer);

            //Act
            IActionResult badr = await fc.ModifyAnswer(1, mardto);

            //Assert

            BadRequestResult badreqres = badr as BadRequestResult;
            Assert.NotNull(badreqres);
        }

        [Fact]

        public async void ModifyAnswerShouldBeNotFound()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);
            DateTime dttime = DateTime.Now;


            ModifyAnswerRequestDTO mardto = new ModifyAnswerRequestDTO()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };

            Answer answer = new Answer()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };


            Mock.Get(forumService)
                .Setup(f => f.ModifyAnswerAsync(answer))
                .ReturnsAsync(null as Answer);


            //Act
            IActionResult notf = await fc.ModifyAnswer(0, mardto);

            //Assert

            NotFoundResult notfoundres = notf as NotFoundResult;
            Assert.NotNull(notfoundres);


        }

        [Fact]
        public async void ModifyAnswerShouldBeOk()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);
            DateTime dttime = DateTime.Now;


            ModifyAnswerRequestDTO mardto = new ModifyAnswerRequestDTO()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };

            Answer answer = new Answer()
            {
                Id = 0,
                Body = "Body",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1
            };


            Mock.Get(forumService)
                .Setup(f => f.ModifyAnswerAsync(answer))
                .ReturnsAsync(answer);


            //Act
            IActionResult okr = await fc.ModifyAnswer(0, mardto);

            //Assert

            OkObjectResult okres = okr as OkObjectResult;
            Assert.NotNull(okres);

        }

        [Fact]

        public async void DeleteAnswerShouldThrowInvalidUserRequestException()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Answer answer = new Answer()
            {
                Id = 1,
                Body = "Answer1",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetAnswerByIdAsync(It.IsAny<int>()))
             .ReturnsAsync(answer);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(2);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(false);


            //Asserts et Act

            await Assert.ThrowsAsync<InvalidUserRequestException>(() => fc.DeleteAnswerAsync(1));




        }

        [Fact]
        public async void DeleteAnswerAsyncShouldBeNotFound()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Answer answer = new Answer()
            {
                Id = 1,
                Body = "Answer1",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetAnswerByIdAsync(It.IsAny<int>()))
             .ReturnsAsync(answer);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(2);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(true);


            //Act

            IActionResult notfoundres = await fc.DeleteAnswerAsync(1);

            //Assert

            NotFoundResult notfres = notfoundres as NotFoundResult;
            Assert.NotNull(notfres);


        }

        [Fact]
        public async void DeleteAnswerAsyncShouldBeNoContent()
        {

            //Arrange
            IForumService forumService = Mock.Of<IForumService>();
            IUserUtils userUtils = Mock.Of<IUserUtils>();
            ForumController fc = new ForumController(forumService, userUtils);
            DateTime dttime = DateTime.Now;


            Answer answer = new Answer()
            {
                Id = 1,
                Body = "Answer1",
                CreationDate = dttime,
                subjectId = 1,
                writerId = 1

            };


            Mock.Get(forumService)
             .Setup(f => f.GetAnswerByIdAsync(It.IsAny<int>()))
             .ReturnsAsync(answer);

            Mock.Get(userUtils)
                .Setup(u => u.GetCurrentUserTokenId())
                .Returns(1);

            Mock.Get(userUtils)
                .Setup(u => u.IsMOD())
                .Returns(true);

            Mock.Get(forumService)
                .Setup(f => f.DeleteAnswerAsync(1))
                .ReturnsAsync(true);


            //Act

            IActionResult noContentres = await fc.DeleteAnswerAsync(1);

            //Assert

            NoContentResult nocres = noContentres as NoContentResult;
            Assert.NotNull(nocres);


        }

        [Fact]

        public async void GetCategoriesShouldBeOk()
        {
            IForumService forumService = Mock.Of<IForumService>();
            ForumController fc = new ForumController(forumService);



        }


    }
}
