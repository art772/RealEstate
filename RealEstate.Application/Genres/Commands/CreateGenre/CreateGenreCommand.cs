using MediatR;

namespace RealEstate.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}