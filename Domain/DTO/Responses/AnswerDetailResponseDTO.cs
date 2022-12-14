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
        public int SubjectId { get; set; }

        public WriterWOloginResponseDTO WriterWOloginResponseDTO { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AnswerDetailResponseDTO dTO &&
                   Id == dTO.Id &&
                   Body == dTO.Body &&
                   CreationDate == dTO.CreationDate &&
                   SubjectId == dTO.SubjectId &&
                   EqualityComparer<WriterWOloginResponseDTO>.Default.Equals(WriterWOloginResponseDTO, dTO.WriterWOloginResponseDTO);
        }
    }
}
