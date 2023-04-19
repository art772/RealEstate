using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.CreateEstate
{
    public class CreateDirectorCommanValidator : AbstractValidator<CreateEstateCommand>
    {
        public CreateDirectorCommanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(10);
        }
    }
}
