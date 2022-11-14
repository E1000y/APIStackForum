using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
   public class SubjectResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WriterId { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreationDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SubjectResponseDTO dTO &&
                   Id == dTO.Id &&
                   Name == dTO.Name &&
                   Description == dTO.Description &&
                   WriterId == dTO.WriterId &&
                   CategoryId == dTO.CategoryId &&
                   CreationDate == dTO.CreationDate;
        }
    }
}
