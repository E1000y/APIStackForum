using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceUWP
{
   public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WriterResponseDTO WriterResponseDTO { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreationDate { get; set; }


       

    }
}
