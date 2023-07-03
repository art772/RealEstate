using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetUserEstates
{
    public class GetUserEstatesQueryHandler : IRequestHandler<GetUserEstatesQuery, UserEstatesVm>
    {
        public Task<UserEstatesVm> Handle(GetUserEstatesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
