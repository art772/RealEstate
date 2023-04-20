using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.CreateEstate
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateEstateCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(10);
        }
    }
}
