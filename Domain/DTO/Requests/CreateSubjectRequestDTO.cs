using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
  public  class CreateSubjectRequestDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public int WriterId { get; set; }

        public int CategoryId { get; set; }

    }
}
