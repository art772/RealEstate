using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class EstateTag
    {
        public int EstateId { get; set; }
        public Estate Estate {get;set;}

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
