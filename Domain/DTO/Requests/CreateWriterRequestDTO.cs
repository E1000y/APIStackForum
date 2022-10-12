using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class CreateWriterRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isModerator { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

    }

    public class CreateWriterRequestDTOValidator : AbstractValidator<CreateWriterRequestDTO>
    {
        public CreateWriterRequestDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.Login).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(250);
        }
    }
}
