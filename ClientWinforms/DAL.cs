using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWinforms
{
    public class DAL
    {
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
    }
}