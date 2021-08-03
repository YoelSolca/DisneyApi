using AutoMapper;
using DisneyApi.Entities;
using DisneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Profiles
{
    public class PersonajeProfiles : Profile
    {
        public PersonajeProfiles()
        {
            CreateMap<Personaje, PersonajeDto>();
            CreateMap<Personaje, PersonajeDetalleDto>();
            CreateMap<Personaje, PersonajesFilters>();
            CreateMap<PersonajeForCreationDto, Personaje>();

            CreateMap<PersonajeForUpdateDto, Personaje>();
            CreateMap<Personaje, PersonajeForUpdateDto>();



        }
    }
}
