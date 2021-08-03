﻿using AutoMapper;
using DisneyApi.Entities;
using DisneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Profiles
{
    public class PeliculaSerieProfiles : Profile
    {
        public PeliculaSerieProfiles()
        {
            CreateMap<PeliculaSerie, PeliculaSerieDto>();
        }
    }
}
