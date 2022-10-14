using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class ModifyPasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
