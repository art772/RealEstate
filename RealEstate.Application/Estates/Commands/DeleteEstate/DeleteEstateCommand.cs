using MediatR;

namespace RealEstate.Application.Estates.Commands.DeleteEstate
{
    public class DeleteEstateCommand : IRequest
    {
        public int EstateId { get; set; }
    }
}