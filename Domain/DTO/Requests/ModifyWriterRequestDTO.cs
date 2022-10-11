using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
    public class ModifyWriterRequestDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsModerator { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
