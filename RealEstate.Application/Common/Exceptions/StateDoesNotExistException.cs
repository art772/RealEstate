using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class StateDoesNotExistException : Exception
    {
        public StateDoesNotExistException() : base(String.Format("State does not exist"))
        {

        }
    }
}
