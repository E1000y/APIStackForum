using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWinforms
{
    public class DAL
    {
        static DAL _dal = null;

        private List<String> roles = new();

        private string userId = "";

        public int getUserId()
        {
            return Int32.Parse(userId); 
        }


        private DAL() { }

        public static DAL getDAL()
        {
            if (_dal == null)
                _dal = new DAL();
            return _dal;
        }


        HttpClient _client = new HttpClient();
        string _token;

        public async Task<string> Login(string nickname, string password)
        {
            AuthentificationRequestDTO authentificationRequestDTO = new() { Login = nickname, Password = password };
            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(authentificationRequestDTO), Encoding.UTF8, "application/json");



            var res = await _client.PostAsync($"{Settings1.Default.ConnectionStringLocal}/accounts/login", jsonBodyParameter);



            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                _token = content;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var handler = new JwtSecurityTokenHandler();
                var tokenDecoded = handler.ReadJwtToken(_token);

                foreach (var item in tokenDecoded.Claims)
                {
                    switch (item.Type)
                    {
                        case ClaimTypes.Role:
                            roles.Add(item.Value);
                            break;
                        case ClaimTypes.NameIdentifier:
                            userId = item.Value;
                            break;
                    }
                }





                return _token;
            }

            return null;
        }

        public async Task<List<Writer>> GetAllUtilisateursAsync()
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}/accounts/");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var lstDTO = JsonSerializer.Deserialize<List<WriterResponseDTO>>(content);

                return lstDTO.ConvertAll(u => new Writer { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, IsModerator = u.IsModerator, Login = u.Login }) ;
            }
            else
                return null;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}/Forum/Subjects");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var lstDTO = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(content);
                return lstDTO.ConvertAll(s => new Subject { Id = s.Id, Name = s.Name, Description = s.Description, categoryId = s.CategoryId, CreationDate = s.CreationDate, writerId = s.WriterId });
            }
            else return null;
        }

        public async Task<List<Answer>> GetAnswersBySubjectIdAsync(int id)
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}/Forum/Subjects/{id}/Answers");
            
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                List<AnswerResponseDTO> lstDTO = JsonSerializer.Deserialize<List<AnswerResponseDTO>>(content);
                var ConvertedLstDTO = lstDTO.ConvertAll(a => new Answer { Id = a.Id, CreationDate = a.CreationDate, writerId = a.WriterId, Body = a.Body, subjectId = a.SubjectId});

                return ConvertedLstDTO;

            }
            else return null;

        }

        public async Task<List<SubjectDetailWriterNameResponseDTO>> GetSubjectsByCategoryId(int id)
        {
            /*var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}/Forum/Subjects");
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                List<SubjectResponseDTO> lstDTO = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(content);
                var ConvertedLstDTO = lstDTO.ConvertAll(s => new Subject { Id = s.Id, Name = s.Name, Description = s.Description, categoryId = s.CategoryId, CreationDate = s.CreationDate, writerId = s.WriterId });
                var FilteredConvertedLstDTO = ConvertedLstDTO.FindAll(s => s.categoryId == id);
                return FilteredConvertedLstDTO;
            }
            else return null;*/


            var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}/forum/categories/{id}/subjects");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                List<SubjectDetailResponseDTO> lstDTO = JsonSerializer.Deserialize<List<SubjectDetailResponseDTO>>(content);
                var ConvertedLstDTO = lstDTO.ConvertAll(s => new SubjectDetailWriterNameResponseDTO { Id = s.Id, Name = s.Name, Description = s.Description, CategoryId = s.CategoryId,  CreationDate = s.CreationDate,  WriterName = s.WriterResponseDTO.FirstName +" "+ s.WriterResponseDTO.LastName
                
                });

                return ConvertedLstDTO;

            }
            else return null;
        }

        internal async Task<Subject> modifySubjectAsync(int modifysubjectId, string modifiedSubjectName, string modifiedSubjectDescription, int activeCategory)
        {
            int writerId = getUserId();
            DateTime creationDate = DateTime.Now;

            ModifySubjectRequestDTO DTOModifySubject = new ModifySubjectRequestDTO { Id = modifysubjectId, Name = modifiedSubjectName, Description = modifiedSubjectDescription, CategoryId = activeCategory, writerId = writerId };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(DTOModifySubject), Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"{Settings1.Default.ConnectionStringLocal}/forum/subjects/{modifysubjectId}", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var DTOModSubject = JsonSerializer.Deserialize<ModifySubjectResponseDTO>(content);
                return new Subject() { Id = DTOModSubject.Id, Name = DTOModSubject.Name, Description = DTOModSubject.Description, categoryId = activeCategory, CreationDate = creationDate, writerId = writerId };
            }
            else return null;

        }

        internal async Task<Answer> modifyAnswerAsync(string modifyAnswerBody, int subjectId, int answerId)
        {
            int writerId = getUserId();
            ModifyAnswerRequestDTO DTOModifiedAnswer = new()
            {
                Id = answerId,
                Body = modifyAnswerBody,
                CreationDate = DateTime.Now,
                subjectId = subjectId,
                writerId = writerId
            };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(DTOModifiedAnswer), Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"{Settings1.Default.ConnectionStringLocal}/forum/answers/{answerId}", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var DTOModAnswer = JsonSerializer.Deserialize<AnswerResponseDTO>(content);
                return new Answer()
                {
                    Body = DTOModAnswer.Body,
                    CreationDate = DTOModAnswer.CreationDate,
                    Id = DTOModAnswer.Id,
                    subjectId = DTOModAnswer.SubjectId,
                    writerId = DTOModAnswer.WriterId
                };
                
            }
            else return null;
        }

        internal async Task<bool> deleteAnswerAsync(int answerId)
        {
            var res = await _client.DeleteAsync($"{Settings1.Default.ConnectionStringLocal}/forum/answers/{answerId}");


            if (res.IsSuccessStatusCode) return true;
            else return false;

        }

        internal async Task<Answer> createAnswerAsync(int subjectId, string addAnswerBody)
        {
            int writerId = getUserId();
            CreateAnswerRequestDTO DTONewAnswer = new()
            {
                Body = addAnswerBody,
                CreationDate = DateTime.Now,
                subjectId = subjectId,
                writerId = writerId
            };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(DTONewAnswer), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionStringLocal}/forum/answers", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var DTOAnswer = JsonSerializer.Deserialize<AnswerResponseDTO>(content);
                return new Answer() { Id = DTOAnswer.Id, Body = DTOAnswer.Body, CreationDate = DTOAnswer.CreationDate, writerId = DTOAnswer.WriterId, subjectId = DTOAnswer.SubjectId };

            }
            else return null;
        }

        internal async Task<Subject> createSubjectAsync(string subjectName, string subjectDescription, int categoryId)
        {
            int writerId = getUserId();
            CreateSubjectRequestDTO DTONewSubject = new() { Name = subjectName, Description = subjectDescription, CategoryId = categoryId, WriterId = writerId };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(DTONewSubject), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionStringLocal}/forum/subjects", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var DTOSubject = JsonSerializer.Deserialize<SubjectResponseDTO>(content);

                return new Subject() { Id = DTOSubject.Id, Name = DTOSubject.Name, Description = DTOSubject.Description, CreationDate = DTOSubject.CreationDate, writerId = DTOSubject.WriterId, categoryId = DTOSubject.CategoryId };

            }
            else return null;


        }

        public async Task<bool> deleteSubjectAsync(int id)
        {
            var res = await _client.DeleteAsync($"{Settings1.Default.ConnectionStringLocal}/forum/subjects/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> ModifyPasswordAsync(string OldPwd, string NewPwd)
        {
            ModifyPasswordDTO modifPwd = new()
            {
                OldPassword = OldPwd,
                NewPassword = NewPwd
            };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(modifPwd), Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"{Settings1.Default.ConnectionStringLocal}/accounts/password/{userId}", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;

        }

        public async Task<bool> CreateWriterAsync(string FirstName, string Lastname, string Login, string Password)
        {
            CreateWriterRequestDTO createWriter = new()
            {
                FirstName = FirstName,
                LastName = Lastname,
                isModerator = false,
                Login = Login,
                Password = Password
            };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(createWriter), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionStringLocal}/accounts", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}