using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UOW;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace BLLS
{
    public class ForumService : IForumService
    {
      


        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;


        public ForumService(IUnitOfWork uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
        }


        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            return await _uow.Subject.GetAllAsync();
        }
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _uow.Subject.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByCategoryId(int categoryId)
        {
            return await _uow.Subject.GetByCategoryIdAsync(categoryId);
        }
        public async Task<Subject> CreateSubjectAsync(Subject newSubject)
        {
            return await _uow.Subject.AddAsync(newSubject);
        }

       

        public async Task<Subject> ModifySubjectAsync(Subject modifiedSubject)
        {
            //await Task.Delay(0);

            //Subject subjectFound = null;

            //foreach (Subject subject in subjects)
            //{
            //    if (subject.Id == modifiedSubject.Id)
            //    {
            //        subjectFound = subject;
            //    }
            //}
            //if (subjectFound == null) return null;

            //subjectFound.Name = modifiedSubject.Name;
            //subjectFound.Description = modifiedSubject.Description;
            //subjectFound.writerId = modifiedSubject.writerId;
            //subjectFound.CreationDate = modifiedSubject.CreationDate;
            //subjectFound.categoryId = modifiedSubject.categoryId;

            //return subjectFound;

            return await _uow.Subject.UpdateAsync(modifiedSubject);

        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {

            _uow.BeginTransaction();

            bool suppressedAnswer = await _uow.Answer.DeleteBySubjectIdAsync(id);
            bool suppressedSubject = await _uow.Subject.DeleteAsync(id);

            if (suppressedAnswer && suppressedSubject)
            {
                _uow.Commit();
                return true;
            }
            else _uow.RollBack();


            return false;
        }

        public async Task<IEnumerable<Answer>> GetAnswersAsync()
        {
            await Task.Delay(0);
            return await _uow.Answer.GetAllAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await _uow.Answer.GetByIdAsync(id);
        }


        public async Task<Answer> CreateAnswerAsync(Answer newAnswer)
        {
            //await Task.Delay(0);
            //int lastId = 0;
            //foreach (Answer ans in answers)
            //{
            //    if (lastId < ans.Id) lastId = ans.Id;
            //}
            //lastId++;

            //newAnswer.Id = lastId;

            //try
            //{
            //    answers.Add(newAnswer);
            //    return newAnswer;
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}

            return await _uow.Answer.AddAsync(newAnswer);
        }

        public async Task<Answer> ModifyAnswerAsync(Answer modifiedAnswer)
        {
            //await Task.Delay(0);
            //Answer answerFound = null;

            //foreach (Answer ans in answers)
            //{
            //    if (ans.Id == modifiedAnswer.Id)
            //    {
            //        answerFound = ans;
            //    }
            //}
            //if (answerFound == null) return null;

            //answerFound.Body = modifiedAnswer.Body;
            //answerFound.subjectId = modifiedAnswer.subjectId;
            //answerFound.writerId = modifiedAnswer.writerId;
            //answerFound.CreationDate = modifiedAnswer.CreationDate;

            //return answerFound;

            return await _uow.Answer.UpdateAsync(modifiedAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            //await Task.Delay(0);
            //Answer answerFound = null;

            //foreach (Answer ans in answers)
            //{
            //    if (ans.Id == id)
            //    {
            //        answerFound = ans;
            //    }
            //}
            //if (answerFound == null) return false;
            //answers.Remove(answerFound);


            return await _uow.Answer.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            await Task.Delay(0);
            return await _uow.Category.GetAllAsync() ;
        }

        public async Task<Category> GetCategoryById(int id)
        {

            return await _uow.Category.GetByIdAsync(id) ;
        }


        public async Task<IEnumerable<Answer>> GetAnswersBySubjectIdAsync(int SubjectId)
        {
            return await _uow.Answer.GetAnswersBySubjectIdAsync(SubjectId);
        }
    }


}
