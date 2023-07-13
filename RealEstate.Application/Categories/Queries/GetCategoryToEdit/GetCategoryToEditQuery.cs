using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Categories.Queries.GetCategoryToEdit
{
    public class GetCategoryToEditQuery : IRequest<CategoryToEditVm>
    {
        public int CategoryId { get; set; }
    }
}
