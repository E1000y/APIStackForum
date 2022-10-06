﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
   public class AnswerResponseDTO
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int WriterId { get; set; }

    }
}
