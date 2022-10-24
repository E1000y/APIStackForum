using Domain.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWinforms2
{
    class DAL
    {
        HttpClient _client = HttpClient();


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

    }
}
