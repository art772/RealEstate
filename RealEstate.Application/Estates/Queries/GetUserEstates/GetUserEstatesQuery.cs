using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetUserEstates
{
    public class GetUserEstatesQuery : IRequest<UserEstatesVm>
    {
        public int UserId { get; set; }
    }
}
