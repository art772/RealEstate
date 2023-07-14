﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get;set; }
    }
}
