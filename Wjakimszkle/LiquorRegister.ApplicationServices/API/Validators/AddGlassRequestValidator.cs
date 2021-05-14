using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;

namespace Wjakimszkle.ApplicationServices.API.Validators
{
    public class AddGlassRequestValidator:AbstractValidator<AddGlassRequest>
    {
        public AddGlassRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(1, 250).WithMessage("WRONG_RANGE");
            this.RuleFor(x => x.Id).LessThanOrEqualTo(100);
        }
    }
}
