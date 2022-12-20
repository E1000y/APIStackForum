using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace InterfaceUWP
{
   public class DataM
    {
        private static volatile DataM _instance;
        private static readonly object _syncRoot = new Object();
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ConnectionString = "http://user40.2isa.org/api/forum/";

        private DataM() { } // Singleton = constructeur privé

        public static DataM Instance // Propriété static pour créer l'instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot) // Verrou pour les accès multi threads
                    {
                        if (_instance == null)
                        {
                            _instance = new DataM();
                        }
                    }
                }

                return _instance;
            }
        }


        public async Task<List<SubjectBO>> GetSubject(int CategoryId)
        {
            Uri uri = new Uri(ConnectionString+ $"categories/{CategoryId}/subjects");
            using (HttpResponseMessage response = await _httpClient.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var dtoSubject = JsonSerializer.Deserialize<List<SubjectDTO>>(res);
                    return dtoSubject.Select(u => new SubjectBO() { id = u.Id, categoryId = u.CategoryId, CreationDate = u.CreationDate, Description = u.Description, Name = u.Name, WriterName = u.WriterResponseDTO.FirstName + " " + u.WriterResponseDTO.LastName } ).ToList();
                }
            }

            return null;
        }


        public async Task<List<AnswerBO>> GetAnswer(int SubjectId)
        {
            Uri uri = new Uri(ConnectionString + $"subjects/{SubjectId}/Answers");
            using (HttpResponseMessage response = await _httpClient.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var dtoAnswer = JsonSerializer.Deserialize<List<AnswerDTO>>(res);
                    return dtoAnswer.Select(u => new AnswerBO() { id = u.Id, subjectId = u.SubjectId, CreationDate = u.CreationDate, WriterName = u.WriterWOloginResponseDTO.FirstName + " " + u.WriterWOloginResponseDTO.LastName, Body = u.Body}).ToList();
                }
            }

            return null;
        }
    }
}

