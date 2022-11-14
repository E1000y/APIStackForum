using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Entity
    {

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }
    }
}
