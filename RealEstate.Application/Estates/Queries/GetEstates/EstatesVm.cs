﻿using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstates
{
    public class EstatesVm
    {
        ICollection<EstateDto> Estates { get; set; }
    }
}