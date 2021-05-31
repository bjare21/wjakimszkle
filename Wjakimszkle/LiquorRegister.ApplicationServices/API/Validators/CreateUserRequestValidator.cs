using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;

namespace Wjakimszkle.ApplicationServices.API.Validators
{
    public class CreateUserRequestValidator:AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("This field is required.")
                .MaximumLength(100).WithMessage("Field is to long.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("This field is required.")
                .MaximumLength(100).WithMessage("Field is to long");

            RuleFor(x => x.Username).NotEmpty().WithMessage("This field is required.")
                .MaximumLength(100).WithMessage("Field is to long.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("This field is required.")
                .EmailAddress().WithMessage("Input correct email address.");
                       
        }
    }
}
