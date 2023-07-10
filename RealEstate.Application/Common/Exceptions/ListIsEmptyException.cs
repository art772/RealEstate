using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class ListIsEmptyException : Exception
    {
        public ListIsEmptyException() : base(String.Format("List is empty"))
        {

        }
    }
}
