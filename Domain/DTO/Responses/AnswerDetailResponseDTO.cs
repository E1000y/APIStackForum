using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
  public  class AnswerDetailResponseDTO
    {

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public WriterResponseDTO WriterResponseDTO { get; set; }
    }
}
