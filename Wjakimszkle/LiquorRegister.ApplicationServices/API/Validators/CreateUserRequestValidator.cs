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
                .MaximumLength(100).WithMessage("Field is to long.")
                .Must(ContainOnlyLetters).WithMessage("This field can contain only letters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("This field is required.")
                .MaximumLength(100).WithMessage("Field is to long")
                .Must(ContainOnlyLetters).WithMessage("This field can contain only letters."); 

            RuleFor(x => x.Username).NotEmpty().WithMessage("This field is required.")
                .MaximumLength(100).WithMessage("Field is to long.")
                .Matches("[A-Za-z0-9]{5,}").WithMessage("Field must contain at least 5 alphanumeric characters.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("This field is required.")
                .EmailAddress().WithMessage("Input correct email address.");
                       
        }

        protected bool ContainOnlyLetters(string text)
        {
            return !text.Any(c => !char.IsLetter(c));
        }
    }
}
