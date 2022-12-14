using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using BLLS;
using Domain.DTO.Responses;

namespace APIStackForum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {

        public static IAccountService _accountService;
        public static ISecurityService _securityService;


        public AccountsController(IAccountService accountService, ISecurityService securityService)
        {
            _accountService = accountService;
            _securityService = securityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthentificationRequestDTO authentificationRequestDTO)
        {
            string token = await _securityService.SigningAsync(authentificationRequestDTO.Login, authentificationRequestDTO.Password);

            return Ok(token);
        }



        [HttpGet]
        public async Task<IActionResult> GetWritersAsync()
        {

            var listWriters = await _accountService.GetWritersAsync();
            var listResponse = new List<WriterResponseDTO>();

            foreach(Writer writer in listWriters)
            {
                listResponse.Add(
                    new WriterResponseDTO()
                {
                    Id = writer.Id,
                    FirstName = writer.FirstName,
                    LastName = writer.LastName,
                    IsModerator = writer.IsModerator,
                    Login = writer.Login
                 
                });
            }



            return Ok(listResponse);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWriterByIdAsync(int id)
        {
            //foreach (Writer writer in writers)
            //{
            //    if (writer.Id == id)
            //    {
            //        return Ok(writer);
            //    }
            //};

            //return NotFound();

            var writer = await _accountService.GetWriterByIdAsync(id);
            if (writer == null) return NotFound();

            var response = new WriterResponseDTO()
            {
                Id = writer.Id,
                FirstName = writer.FirstName,
                LastName = writer.LastName,
                IsModerator = writer.IsModerator,
                Login = writer.Login
            };


            return  Ok(response);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyWriterAsync([FromRoute] int id, [FromBody] ModifyWriterRequestDTO modifiedWriterDTO)
        {
            //Vérifier que l'id de la route et l'id du modifiedWriterDTO soient les mêmes
            if (id != modifiedWriterDTO.Id) return BadRequest();

            //DTO -> objet métier

            Writer modifiedWriter = new Writer()
            {
                Id = modifiedWriterDTO.Id,
                FirstName = modifiedWriterDTO.FirstName,
                LastName = modifiedWriterDTO.LastName,
                IsModerator = modifiedWriterDTO.IsModerator,
                Login = modifiedWriterDTO.Login
            };


            var writer = await _accountService.ModifyWriterAsync(modifiedWriter);

            //Création de la réponse

            if (writer is null) return NotFound();

            var response = new WriterResponseDTO()
            {
                Id = writer.Id,
                FirstName = writer.FirstName,
                LastName = writer.LastName,
                IsModerator = writer.IsModerator,
                Login = writer.Login
            };



            return Ok(response);

        }

        //ajouter un writer
        [HttpPost("")]

        public async Task<IActionResult> CreateWriterAsync([FromBody] CreateWriterRequestDTO createWriterRequestDTO)
        {
            //DTO -> objet métier

            Writer newWriter = new Writer()
            {
                FirstName = createWriterRequestDTO.FirstName,
                LastName = createWriterRequestDTO.LastName,
                IsModerator = createWriterRequestDTO.isModerator,
                Login = createWriterRequestDTO.Login,
                Password = createWriterRequestDTO.Password
            };


            // Délègue à la couche inférieure la création de l'auteur

            Writer writer = await _securityService.CreateWriterAsync(newWriter);


            //Renvoie la réponse sous forme de DTO de réponse
            if (writer is null)
            {
                return BadRequest();
                
            }
            else
            {
                return CreatedAtAction(nameof(GetWriterByIdAsync), new { id = writer.Id }, new WriterResponseDTO()
                {
                    Id = writer.Id,
                    FirstName = writer.FirstName,
                    LastName = writer.LastName,
                    IsModerator = writer.IsModerator,
                    Login = writer.Login
                });
            }

        }

        //Supprimer un writer

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteWriterAsync([FromRoute] int id)
        {

            return (await _accountService.DeleteWriterAsync(id)) ? NoContent() : NotFound();
        }

        [HttpPut("password/{id}")]

        public async Task<IActionResult> ModifyPasswordAsync([FromRoute] int id, [FromBody] ModifyPasswordDTO modifyPasswordDTO)
        {
            bool OkPasswordModified = await _securityService.ModifyPasswordAsync(id, modifyPasswordDTO.OldPassword, modifyPasswordDTO.NewPassword);



            return Ok(OkPasswordModified);
        }

    }
}
