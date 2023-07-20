using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class GenreDoesNotExistException : Exception
    {
        public GenreDoesNotExistException() : base(String.Format("Genre does not exist"))
        {

        }
    }
}
