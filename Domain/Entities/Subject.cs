using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Subject : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public int writerId { get; set; }

        public int categoryId { get; set; }
    }
}
