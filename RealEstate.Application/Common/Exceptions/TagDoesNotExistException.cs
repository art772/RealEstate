using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class TagDoesNotExistException : Exception
    {
        public TagDoesNotExistException() : base(String.Format("Tag does not exist"))
        {
        }
    }
}
