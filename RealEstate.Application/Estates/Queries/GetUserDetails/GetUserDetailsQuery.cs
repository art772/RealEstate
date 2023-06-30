using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDto>
    {
        public int Id { get; set; }
    }
}
