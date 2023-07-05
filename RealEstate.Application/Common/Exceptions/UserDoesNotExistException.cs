using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() : base(String.Format("User does not exist"))
        {

        }
    }
}
