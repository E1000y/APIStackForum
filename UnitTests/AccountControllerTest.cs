using APIStackForum.Controllers;
using BLLS;
using Domain.DTO.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class AccountControllerTest
    {
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

            IEnumerable<WriterResponseDTO> expectedContentResult = listWriters.Select(w => new WriterResponseDTO()
            {
                Id = w.Id,
                FirstName = w.FirstName,
                LastName = w.LastName,
                IsModerator = w.IsModerator,
                Login = w.Login,
                Password = w.Password
            });


            Mock.Get(accountservice)
                .Setup(a => a.GetWritersAsync())
                .ReturnsAsync(listWriters);

            AccountsController accountsController = new AccountsController(accountservice);


            IActionResult okResult = await accountsController.GetWritersAsync();

            OkObjectResult result = okResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(result.Value as List<WriterResponseDTO> , expectedContentResult.ToList());



        }
    }
}
