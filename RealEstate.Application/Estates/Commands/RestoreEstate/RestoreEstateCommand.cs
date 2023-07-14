using MediatR;

namespace RealEstate.Application.Estates.Commands.RestoreEstate
{
    public class RestoreEstateCommand : IRequest<int>
    {
        public int EstateId { get; set; }
    }
}