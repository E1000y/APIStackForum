using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
    class AnswerDetailWriterNameResponseDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int SubjectId { get; set; }

        public string WriterName { get; set; }
    }
}
