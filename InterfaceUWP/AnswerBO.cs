using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceUWP
{
    public class AnswerBO
    {
        public int id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }

        public int writerId { get; set; }

        public int subjectId { get; set; }

    }
}
