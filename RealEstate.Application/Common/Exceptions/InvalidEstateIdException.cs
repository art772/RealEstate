using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class InvalidEstateIdException : Exception
    {
        public InvalidEstateIdException()
        {

        }
        public InvalidEstateIdException(int id) : base(String.Format($"Estate with Id: {id} doesn't exist"))
        {

        }
    }
}
