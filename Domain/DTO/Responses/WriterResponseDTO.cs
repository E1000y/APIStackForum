using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
   public class WriterResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsModerator { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WriterResponseDTO dTO &&
                   Id == dTO.Id &&
                   FirstName == dTO.FirstName &&
                   LastName == dTO.LastName &&
                   IsModerator == dTO.IsModerator &&
                   Login == dTO.Login &&
                   Password == dTO.Password;
        }
    }
}
