using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class EstatePhoto : Photo
    {
        public bool IsMain { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
