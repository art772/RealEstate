using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.UpdateEstate
{
    public class UpdateEstateCommandValidator : AbstractValidator<UpdateEstateCommand>
    {
        public UpdateEstateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(5).MaximumLength(1000);
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.StreetNumber).NotEmpty().MaximumLength(8);
            RuleFor(x => x.FlatNumber).NotEmpty().MaximumLength(8);
            RuleFor(x => x.City).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(8);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Price).NotEmpty().ExclusiveBetween(1, 9999999999);
            RuleFor(x => x.EstateArea).NotEmpty().ExclusiveBetween(1, 999999);
            RuleFor(x => x.YearOfConstruction).NotEmpty();
        }
    }
}
