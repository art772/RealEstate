using MediatR;

namespace RealEstate.Application.Users.Commands.EditUserData
{
    public class EditUserDataCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}