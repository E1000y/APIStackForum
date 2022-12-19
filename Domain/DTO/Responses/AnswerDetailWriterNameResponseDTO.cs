using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
    public class AnswerDetailWriterNameResponseDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int SubjectId { get; set; }

        public string WriterName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AnswerDetailWriterNameResponseDTO dTO &&
                   Id == dTO.Id &&
                   Body == dTO.Body &&
                   CreationDate == dTO.CreationDate &&
                   SubjectId == dTO.SubjectId &&
                   WriterName == dTO.WriterName;
        }
    }
}
