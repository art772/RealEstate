using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.GetUserEstates
{
    public class GetUserEstatesQuery : IRequest<List<UserEstatesVm>>
    {
        public int UserId { get; set; }
    }
}
