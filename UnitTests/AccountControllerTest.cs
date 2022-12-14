using APIStackForum.Controllers;
using BLLS;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace UnitTests
{
    public class AccountControllerTest
    {
        
       /* [Fact]

        public async void LoginShouldBeOk()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IAccountService accountService = Mock.Of<IAccountService>();



            AuthentificationRequestDTO authentificationRequestDTO = new AuthentificationRequestDTO()
            {
                Login = "login",
                Password = "password"
            };

            string result = null;

            Mock.Get(securityService)
                .Setup(s => s.SigningAsync(authentificationRequestDTO.Login, authentificationRequestDTO.Password))
                .Returns(result );

            AccountsController accountsController = new AccountsController(accountService, securityService);

            //Act

            IActionResult actionResult = await accountsController.LoginAsync(authentificationRequestDTO);


            //Assert


        }*/
        



        [Fact]
        public async void GetWritersShouldBeOk()
        {
            List<Writer> listWriters = new List<Writer>()
            {
            new Writer(){Id = 1, FirstName = "Alexandre", IsModerator = true, LastName = "Dumas", Login = "ad", Password ="pwdad"},
            new Writer(){Id = 2, FirstName = "firstname2", LastName = "lastname2", Login="login2", Password = "pwd2"},
            new Writer(){Id = 3, FirstName = "firstname3", LastName = "lastname3", Login = "login3", Password = "pwd3"},

            };
            IAccountService accountservice = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            IEnumerable<WriterResponseDTO> expectedContentResult = listWriters.Select(w => new WriterResponseDTO()
            {
                Id = w.Id,
                FirstName = w.FirstName,
                LastName = w.LastName,
                IsModerator = w.IsModerator,
                Login = w.Login
            });


            Mock.Get(accountservice)
                .Setup(a => a.GetWritersAsync())
                .ReturnsAsync(listWriters);

            AccountsController accountsController = new AccountsController(accountservice, securityService);


            IActionResult okResult = await accountsController.GetWritersAsync();

            OkObjectResult result = okResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(result.Value as List<WriterResponseDTO> , expectedContentResult.ToList());



        }

        [Fact]

        public async void GetWritersByIdShouldBeNotFound()
        {
            //Arrange = organiser les donn?es
            IAccountService accountservice = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            Mock.Get(accountservice)
                .Setup(a => a.GetWriterByIdAsync(1))
                .ReturnsAsync(null as Writer);
            
            AccountsController accountsController = new AccountsController(accountservice, securityService);
            //Act = action
            IActionResult okResult = await accountsController.GetWriterByIdAsync(1);

            //Assert : comparer les valeurs
            NotFoundResult notFoundResult = okResult as NotFoundResult;
            Assert.NotNull(notFoundResult);
           

        }

        [Fact]

        public async void GetWritersByIdShouldBeOk()
        {
            //Arrange = organiser les donn?es
            IAccountService accountservice = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            Mock.Get(accountservice)
                .Setup(a => a.GetWriterByIdAsync(1))
                .ReturnsAsync(new Writer()
                {
                    Id = 1,
                    FirstName = "",
                    LastName = "",
                    IsModerator = false,
                    Login = "",
                    Password = ""
                }
                );
            AccountsController accountscontroller = new AccountsController(accountservice, securityService);

            //Act
            IActionResult okResult = await accountscontroller.GetWriterByIdAsync(1);

            //Assert
            OkObjectResult result = okResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(result.Value as WriterResponseDTO, new WriterResponseDTO
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                IsModerator = false,
                Login = "",


            });
        }
        [Fact]
        public async void ModifyWriterAsyncShouldBeBadRequest()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            AccountsController accountsController = new AccountsController(accountService, securityService);

            ModifyWriterRequestDTO modifyWriterRequest = new ModifyWriterRequestDTO()
            {
                Id = 5
            };

            //Act
            IActionResult result = await accountsController.ModifyWriterAsync(1, modifyWriterRequest);

            //Assert
            Assert.NotNull(result as BadRequestResult);
            Assert.True(result is BadRequestResult);

        }

        [Fact]
        public async void ModifyWriterAsyncShouldBeNotFound()
        {
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            Mock.Get(accountService)
                .Setup(a => a.ModifyWriterAsync(It.IsAny<Writer>()))
                .ReturnsAsync(null as Writer);

            AccountsController accountsController = new AccountsController(accountService, securityService);

            ModifyWriterRequestDTO modifywriterdto = new ModifyWriterRequestDTO()
            {
                Id = 5,
            };

            //Act

            IActionResult result = await accountsController.ModifyWriterAsync(5, modifywriterdto);

            //Assert
            Assert.NotNull(result as NotFoundResult);
            Assert.True(result is NotFoundResult);
        }

        [Fact]
        public async void ModifyWriterAsyncShouldBeOk()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            ModifyWriterRequestDTO  writerdto   = new ()
            {
                Id = 5,
                FirstName = "toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login"
            };


            Writer writer = new Writer()
            {
                Id = 5,
                FirstName = "toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login"
            };

            Mock.Get(accountService)
                .Setup(a => a.ModifyWriterAsync(writer))
                .ReturnsAsync(writer);

            AccountsController accountsController = new AccountsController(accountService, securityService);

            //Act
            IActionResult result = await accountsController.ModifyWriterAsync(5, writerdto);

            //Assert

            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(okResult.Value as WriterResponseDTO, new WriterResponseDTO
            {
                Id = 5,
                FirstName = "toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login"
            });

        }

        [Fact]
        public async void CreateWriterShouldBeBadRequest()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            CreateWriterRequestDTO cwdto = new CreateWriterRequestDTO()
            {
                FirstName = "",
                LastName = "lastname",
                isModerator = true,
                Login = "login",
                Password = "password"
            };

            Writer writer = new Writer()
            {
                Id = 5,
                FirstName = "",
                LastName = "machin",
                IsModerator = true,
                Login = "login"
            };

            AccountsController accountsController = new AccountsController(accountService, securityService);

            Mock.Get(securityService)
               .Setup(a => a.CreateWriterAsync(writer))
               .ReturnsAsync(null as Writer);

            //Act
            IActionResult result = await accountsController.CreateWriterAsync(cwdto);


            //Assert
            BadRequestResult badResult = result as BadRequestResult;
            Assert.NotNull(badResult);



        }
        [Fact]

        public async void CreateWriterShouldBeOk()
        {

            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();

            CreateWriterRequestDTO cwdto = new CreateWriterRequestDTO()
            {
                FirstName = "Toto",
                LastName = "machin",
                isModerator = true,
                Login = "login",
                Password = "password"
            };

            Writer writer = new Writer()
            {
                FirstName = "Toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login", 
                Password="password"
            };
            Writer writerOut = new Writer()
            {
                Id = 5,
                FirstName = "Toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login"
            };


            AccountsController accountsController = new AccountsController(accountService, securityService);

            Mock.Get(securityService)
               .Setup(a => a.CreateWriterAsync(writer))
               .ReturnsAsync(writerOut);

            //Act

            IActionResult result = await accountsController.CreateWriterAsync(cwdto);


            //Assert
            CreatedAtActionResult okResult = result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(okResult.Value as WriterResponseDTO, new WriterResponseDTO
            {
                Id = 5,
                FirstName = "Toto",
                LastName = "machin",
                IsModerator = true,
                Login = "login",
                
            });


        }

        [Fact]
        public async void DeleteWriterShouldBeNotFound()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();


            AccountsController accountsController = new AccountsController(accountService, securityService);

            Mock.Get(accountService)
               .Setup(a => a.DeleteWriterAsync(It.IsAny<int>()))
               .ReturnsAsync(false);

            //Act
            IActionResult result = await accountsController.DeleteWriterAsync(5);

            NotFoundResult nfResult = result as NotFoundResult;

            //Assert
            Assert.NotNull(nfResult);
            Assert.IsType<NotFoundResult>(nfResult);
            


        }

        [Fact]

        public async void DeleteWriterShouldBeNoContent()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();


            AccountsController accountsController = new AccountsController(accountService, securityService);

            Mock.Get(accountService)
               .Setup(a => a.DeleteWriterAsync(It.IsAny<int>()))
               .ReturnsAsync(true);

            //Act
            IActionResult result = await accountsController.DeleteWriterAsync(5);

            NoContentResult nfResult = result as NoContentResult;

            //Assert
            Assert.NotNull(nfResult);
            Assert.IsType<NoContentResult>(nfResult);

        }
        [Fact]

        public async void ModifyPasswordShouldBeOk()
        {
            //Arrange
            IAccountService accountService = Mock.Of<IAccountService>();
            ISecurityService securityService = Mock.Of<ISecurityService>();


            AccountsController accountsController = new AccountsController(accountService, securityService);

            ModifyPasswordDTO mpwdto = new ModifyPasswordDTO
            {
                OldPassword = "oldpwd",
                NewPassword = "newpwd"
            };

            Mock.Get(securityService)
                .Setup(s => s.ModifyPasswordAsync(It.IsAny<int>(), mpwdto.OldPassword, mpwdto.NewPassword))
                .ReturnsAsync(true);

            //Act
            IActionResult OkPasswordModified = await accountsController.ModifyPasswordAsync(1,  mpwdto);

            //Assert
            OkObjectResult Okpwd = OkPasswordModified as OkObjectResult;

            Assert.IsType<OkObjectResult>(Okpwd);

          }
    }
}
