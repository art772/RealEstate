using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.RestoreEstate
{
    public class RestoreEstateCommand : IRequest<int>
    {
        public int EstateId { get; set; }
    }
}
