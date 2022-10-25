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

        public async Task<List<Subject>> GetSubjectsByCategoryId(int id)
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
                List<SubjectResponseDTO> lstDTO = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(content);
                var ConvertedLstDTO = lstDTO.ConvertAll(s => new Subject { Id = s.Id, Name = s.Name, Description = s.Description, categoryId = s.CategoryId, CreationDate = s.CreationDate, writerId = s.WriterId });

                return ConvertedLstDTO;

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
    }
}