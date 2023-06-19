using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Common.Exceptions
{
    public class PreviouslyDeletedEstateException : Exception
    {
        public PreviouslyDeletedEstateException() : base(String.Format("This estate has been removed"))
        {

        }
    }
}
