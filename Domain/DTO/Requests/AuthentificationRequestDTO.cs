using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class AuthentificationRequestDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }

    }

    public class AuthentificationRequestDTOValidator : AbstractValidator<AuthentificationRequestDTO>
    {
        public AuthentificationRequestDTOValidator()
        {
            RuleFor(x => x.Login).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
            
        }

    }
}
