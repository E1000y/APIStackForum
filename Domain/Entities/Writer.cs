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

        public override bool Equals(object obj)
        {
            return obj is Writer writer &&
                   Id == writer.Id &&
                   FirstName == writer.FirstName &&
                   LastName == writer.LastName &&
                   IsModerator == writer.IsModerator &&
                   Login == writer.Login &&
                   Password == writer.Password;
        }
    }



}
