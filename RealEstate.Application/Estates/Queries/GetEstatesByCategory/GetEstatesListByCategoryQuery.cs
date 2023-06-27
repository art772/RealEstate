using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstatesByCategory
{
    public class GetEstatesListByCategoryQuery : IRequest<List<EstateByCategoryDto>>
    {
        public int CategoryId { get; set; }
    }
}
