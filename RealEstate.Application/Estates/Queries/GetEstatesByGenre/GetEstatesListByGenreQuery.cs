﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstatesByGenre
{
    public class GetEstatesListByGenreQuery : IRequest<List<EstateByGenreVm>>
    {
        public int GenreId { get; set; }
    }
}
