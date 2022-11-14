using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses
{
   public class CategoriesResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoriesResponseDTO dTO &&
                   Id == dTO.Id &&
                   Title == dTO.Title;
        }
    }
}
