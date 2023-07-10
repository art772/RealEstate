using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstatesByState
{
    public class GetEstatesListByStateQuery : IRequest<List<EstateByStateVm>>
    {
        public int SateId { get; set; }
    }
}
