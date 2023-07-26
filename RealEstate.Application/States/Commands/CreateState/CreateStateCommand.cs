using MediatR;

namespace RealEstate.Application.States.Commands.CreateState
{
    public class CreateStateCommand : IRequest<int>
    {
        public string Name { get;set; }
    }
}