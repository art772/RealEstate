using MediatR;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.States.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}