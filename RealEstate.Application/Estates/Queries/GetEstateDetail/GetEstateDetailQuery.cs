using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstateDetail
{
    public class GetEstateDetailQuery : IRequest<EstateDetailVm>
    {
        public int EstateId { get; set; }
    }
}
