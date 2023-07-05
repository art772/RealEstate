using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class EstatesListEmptyException : Exception
    {
        public EstatesListEmptyException() : base(String.Format("Estates list is empty"))
        {

        }
    }
}
