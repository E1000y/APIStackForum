using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class CreateWriterRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isModerator { get; set; }

    }
}
