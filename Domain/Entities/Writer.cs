using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Writer : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsModerator { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

    }
}
