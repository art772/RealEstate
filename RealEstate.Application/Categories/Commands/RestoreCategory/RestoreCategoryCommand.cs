using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
    }
}
