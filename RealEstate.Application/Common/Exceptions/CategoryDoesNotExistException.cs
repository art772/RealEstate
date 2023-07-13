using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class CategoryDoesNotExistException : Exception
    {
        public CategoryDoesNotExistException() : base(String.Format("Category does not exist"))
        {
        }
    }
}
