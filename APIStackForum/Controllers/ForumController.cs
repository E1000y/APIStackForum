using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLLS;
using Domain.Entities;
using Domain.Exceptions;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace APIStackForum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {

        public static IForumService _forumService;
        public static IAccountService _accountService;

        public ForumController(IForumService forumService, IAccountService accountService)
        {
            _forumService = forumService;
            _accountService = accountService;
        }



        [HttpGet("subjects")]

        public async Task<IActionResult> GetSubjectsAsync()
        {
            var listSubjects = await _forumService.GetSubjectsAsync();
            var listResponse = new List<SubjectResponseDTO>();

            foreach (Subject subject in listSubjects)
            {
                listResponse.Add(
                    new SubjectResponseDTO
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Description = subject.Description,
                        CategoryId = subject.categoryId,
                        WriterId = subject.writerId,
                        CreationDate = subject.CreationDate
                    });
            }

            return Ok(listResponse);
        }


        [HttpGet("subjects/{id}")]

        public async Task<IActionResult> GetSubjectByIdAsync([FromRoute] int id)
        {
            Subject subject = await _forumService.GetSubjectByIdAsync(id);
            if (subject == null) return NotFound();

            var response = new SubjectResponseDTO()
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                CategoryId = subject.categoryId,
                WriterId = subject.writerId,
                CreationDate = subject.CreationDate
            };
            return Ok(response);
        }

        [HttpGet("subjects/{SubjectId}/answers")]

        public async Task<IActionResult> GetAnswersBySubjectIdAsync([FromRoute] int SubjectId)
        {
            var answers = await _forumService.GetAnswersBySubjectIdAsync(SubjectId);
            if (answers.Count() == 0) return NotFound();

            List<AnswerDetailResponseDTO> response = new List<AnswerDetailResponseDTO>();

            foreach (Answer ans in answers)
            {
                var writerIdentified = await _accountService.GetWriterByIdAsync(ans.writerId);

                response.Add(new AnswerDetailResponseDTO
                {
                    Id = ans.Id,
                    Body = ans.Body,
                    CreationDate = ans.CreationDate,
                    SubjectId = ans.subjectId,
                    WriterWOloginResponseDTO = new WriterWOloginResponseDTO
                    {
                        Id = writerIdentified.Id,
                        FirstName = writerIdentified.FirstName,
                        LastName = writerIdentified.LastName,
                        IsModerator = writerIdentified.IsModerator
                    }
                });
            }
            return Ok(response);
        }

        [HttpGet("categories/{CategoryId}/subjects")]

        public async Task<IActionResult> GetSubjectsByCategoryIdAsync([FromRoute] int CategoryId)
        {
            var subjects = await _forumService.GetSubjectsByCategoryId(CategoryId);

            if (subjects.Count() == 0) return NotFound();

            //List<SubjectResponseDTO> response = new List<SubjectResponseDTO>() ;

            //foreach(Subject subject in subjects)
            //{
            //response.Add(new SubjectResponseDTO
            //{
            //    Id = subject.Id,
            //    Name = subject.Name,
            //    Description = subject.Description,
            //    CategoryId = subject.categoryId,
            //    WriterId = subject.writerId,
            //    CreationDate = subject.CreationDate

            //}); 


            List<SubjectDetailResponseDTO> response = new List<SubjectDetailResponseDTO>();

            //var writers = await _accountService.GetWritersAsync();

            //Writer writerIdentified = null;

            //foreach (Writer writer in writers)
            //{
            //    foreach(Subject subject in subjects)
            //    {
            //    if(writer.Id == subject.writerId)
            //        {
            //            writerIdentified = writer;
            //        }
            //    }
            //}

            //WriterResponseDTO WriterRewritten = new WriterResponseDTO
            //{
            //    Id = writerIdentified.Id,
            //    FirstName = writerIdentified.FirstName,
            //    IsModerator = writerIdentified.IsModerator,
            //    LastName = writerIdentified.LastName,
            //    Login = writerIdentified.Login
            //};

            foreach (Subject subject in subjects)
            {
                var writerIdentified = await _accountService.GetWriterByIdAsync(subject.writerId);
                     WriterResponseDTO WriterRewritten = new WriterResponseDTO
                     {
                         Id = writerIdentified.Id,
                         FirstName = writerIdentified.FirstName,
                         IsModerator = writerIdentified.IsModerator,
                         LastName = writerIdentified.LastName,
         
                     };
                response.Add(new SubjectDetailResponseDTO
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                    CategoryId = subject.categoryId,
                    CreationDate = subject.CreationDate,
                    WriterResponseDTO = WriterRewritten,

                }) ;

            }

        
                    return Ok(response);
    }

    [HttpPost("subjects")]
    public async Task<IActionResult> CreateSubjectAsync([FromBody] CreateSubjectRequestDTO newSubjectDTO)
    {
        //DTO -> objet métier

        Subject subject = new Subject()
        {
            Name = newSubjectDTO.Name,
            Description = newSubjectDTO.Description,
            CreationDate = DateTime.Now,
            writerId = newSubjectDTO.WriterId,
            categoryId = newSubjectDTO.CategoryId
        };

        //Délègue à la couche inférieure la création du Sujet

        var createdsubject = await _forumService.CreateSubjectAsync(subject);

        //Renvoie la réponse sous forme de DTO de réponse

        if (createdsubject == null)
        {
            return BadRequest();

        }
        else
        {
            return CreatedAtAction(nameof(GetSubjectByIdAsync), new { Id = createdsubject.Id }, new SubjectResponseDTO()
            {
                Id = createdsubject.Id,
                Name = createdsubject.Name,
                Description = createdsubject.Description,
                CreationDate = createdsubject.CreationDate,
                WriterId = createdsubject.writerId,
                CategoryId = createdsubject.categoryId
            });
        }
    }
    [HttpPut("subjects/{id}")]

    public async Task<IActionResult> ModifySubjectAsync([FromRoute] int id, [FromBody] ModifySubjectRequestDTO modifiedSubjectDTO)
    {
        //Vérifier que l'id de la route et l'id du subjectDTO soient les mêmes

        if (id != modifiedSubjectDTO.Id) return BadRequest();

        // DTO-> objet métier

        Subject modifiedSubject = new Subject()
        {
            Id = modifiedSubjectDTO.Id,
            Name = modifiedSubjectDTO.Name,
            Description = modifiedSubjectDTO.Description,
            writerId = modifiedSubjectDTO.writerId,
            categoryId = modifiedSubjectDTO.CategoryId,
            CreationDate = DateTime.Now
        };

        Subject subject = await _forumService.ModifySubjectAsync(modifiedSubject);

        //Création de la réponse

        if (subject == null) return NotFound();

        var response = new SubjectResponseDTO()
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            CreationDate = subject.CreationDate,
            WriterId = subject.writerId,
            CategoryId = subject.categoryId


        };

        return Ok(response);

    }
    [HttpDelete("subjects/{id}")]
    [Authorize(Roles = "MOD,USER")]

    public async Task<IActionResult> DeleteSubjectAsync([FromRoute] int id, [FromServices] IUserUtils userUtils)
    {
        int InTokenId = userUtils.GetCurrentUserTokenId(this);

        Subject enquiredSubject = await _forumService.GetSubjectByIdAsync(id);

        if (!userUtils.IsMOD(this) && enquiredSubject.writerId != InTokenId) throw new InvalidUserRequestException();

        return (await _forumService.DeleteSubjectAsync(id)) ? NoContent() : NotFound();
    }

    //private int GetCurrentUserTokenId()
    //{
    //    return Int32.Parse((HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value));
    //}

    [HttpGet("answers")]

    public async Task<IActionResult> GetAnswersAsync()
    {
        var listAnswers = await _forumService.GetAnswersAsync();
        var listResponse = new List<AnswerResponseDTO>();

        foreach (Answer answer in listAnswers)
        {
            listResponse.Add(
                new AnswerResponseDTO()
                {
                    Id = answer.Id,
                    Body = answer.Body,
                    SubjectId = answer.subjectId,
                    WriterId = answer.writerId,
                    CreationDate = answer.CreationDate
                });

        }
        return Ok(listResponse);
    }

    [HttpGet("answers/{id}")]
    public async Task<IActionResult> GetAnswerByIdAsync([FromRoute] int id)
    {
        Answer answer = await _forumService.GetAnswerByIdAsync(id);
        if (answer == null) return NotFound();

        Writer writer = await _accountService.GetWriterByIdAsync(answer.writerId);

            WriterWOloginResponseDTO writerWOloginResponse = new WriterWOloginResponseDTO
            {
                Id = writer.Id,
                FirstName = writer.FirstName,
                LastName = writer.LastName,
                IsModerator = writer.IsModerator
            };


        var response = new AnswerDetailResponseDTO()
        {
            Id = answer.Id,
            Body = answer.Body,
            SubjectId = answer.subjectId,
            WriterWOloginResponseDTO = writerWOloginResponse,
            CreationDate = answer.CreationDate
        };
        return Ok(response);
    }

    [HttpPost("answers")]

    public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerRequestDTO createdAnswer)
    {
        //DTO => objet métier

        Answer newAnswer = new Answer()
        {

            Body = createdAnswer.Body,
            CreationDate = createdAnswer.CreationDate,
            subjectId = createdAnswer.subjectId,
            writerId = createdAnswer.writerId
        };

        var answer = await _forumService.CreateAnswerAsync(newAnswer);

        if (answer != null)
        {
            return CreatedAtAction(nameof(GetAnswerByIdAsync), new { Id = answer.Id }, new AnswerResponseDTO()
            {
                Id = answer.Id,
                Body = answer.Body,
                SubjectId = answer.subjectId,
                WriterId = answer.writerId,
                CreationDate = answer.CreationDate
            });
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpPut("answers/{id}")]

    public async Task<IActionResult> ModifyAnswer([FromRoute] int id, [FromBody] ModifyAnswerRequestDTO modifiedAnswerDTO)
    {
        //Vérifier que l'id de la route et du dto soient les mêmes
        if (modifiedAnswerDTO.Id != id) return BadRequest();

        //Traduire le DTO en objet métier
        Answer modifiedAnswer = new Answer()
        {
            Id = modifiedAnswerDTO.Id,
            Body = modifiedAnswerDTO.Body,
            subjectId = modifiedAnswerDTO.subjectId,
            writerId = modifiedAnswerDTO.writerId,
            CreationDate = modifiedAnswerDTO.CreationDate
        };

        var answer = await _forumService.ModifyAnswerAsync(modifiedAnswer);

        //Création de la réponse

        if (answer is null) return NotFound();

        var response = new AnswerResponseDTO()
        {
            Id = answer.Id,
            Body = answer.Body,
            SubjectId = answer.subjectId,
            WriterId = answer.writerId,
            CreationDate = answer.CreationDate
        };

        return Ok(response);


    }
    [HttpDelete("answers/{id}")]
    [Authorize(Roles = "MOD,USER")]

    public async Task<IActionResult> DeleteAnswerAsync([FromRoute] int id, [FromServices] IUserUtils userUtils)
    {

        int InTokenId = userUtils.GetCurrentUserTokenId(this);

        Answer enquiredAnswer = await _forumService.GetAnswerByIdAsync(id);

        if (!userUtils.IsMOD(this) && enquiredAnswer.writerId != InTokenId) throw new InvalidUserRequestException();
        return (await _forumService.DeleteAnswerAsync(id)) ? NoContent() : NotFound();


    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var listCategories = await _forumService.GetCategories();
        var listResponse = new List<CategoriesResponseDTO>();

        foreach (Category category in listCategories)
        {
            listResponse.Add(
                new CategoriesResponseDTO()
                {
                    Id = category.Id,
                    Title = category.Title
                });
        }

        return Ok(listResponse);
    }

    [HttpGet("categories/{id}")]

    public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
    {

        var category = await _forumService.GetCategoryById(id);
        if (category == null) return NotFound();
        var response = new CategoriesResponseDTO()
        {
            Id = category.Id,
            Title = category.Title
        };

        return Ok(response);
    }

}
}
        