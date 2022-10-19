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



            var res = await _client.PostAsync($"{Settings1.Default.ConnectionStringLocal}", jsonBodyParameter);



            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                _token = content;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                return _token;
            }

            return null;
        }

        public async Task<List<Subject>> GetAllUtilisateursAsync()
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionStringLocal}");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var lstDTO = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(content);

                return lstDTO.ConvertAll(u => new Subject { Id = u.Id, Name = u.Name, Description = u.Description });
            }
            else
                return null;
        }
    }
}