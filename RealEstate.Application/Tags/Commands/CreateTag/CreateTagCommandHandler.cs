using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly IEstateDbContext _context;

        public CreateTagCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag()
            {
                Name = request.Name,
            };

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync(cancellationToken);

            return tag.Id;
        }
    }
}