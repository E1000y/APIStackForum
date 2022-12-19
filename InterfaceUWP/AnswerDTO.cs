using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceUWP
{
   public class AnswerDTO
    {

        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public WriterWOloginResponseDTO WriterWOloginResponseDTO { get; set; }

    }
}
