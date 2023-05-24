using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.DeleteEstate
{
    public class DeleteEstateCommand : IRequest
    {
        public int EstateId { get; set; }
    }
}
