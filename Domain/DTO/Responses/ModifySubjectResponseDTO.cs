using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
   public class ModifySubjectResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WriterId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ModifySubjectResponseDTO dTO &&
                   Id == dTO.Id &&
                   Name == dTO.Name &&
                   Description == dTO.Description &&
                   WriterId == dTO.WriterId;
        }
    }
}
