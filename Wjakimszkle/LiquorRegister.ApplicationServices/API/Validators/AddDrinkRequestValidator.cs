using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;

namespace Wjakimszkle.ApplicationServices.API.Validators
{
    public class AddDrinkRequestValidator:AbstractValidator<AddDrinkRequest>
    {
        public AddDrinkRequestValidator()
        {
            this.RuleFor(x => x.AlcoholByVolume).InclusiveBetween(0, 100).WithMessage("OUT_OF_RANGE");
            this.RuleFor(x => x.Name).MaximumLength(255);
        }
    }
}
