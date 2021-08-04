using DisneyApi.Entities;
using DisneyApi.Models;
using DisneyApi.Models.PeliculaSerie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Services
{
    public class PersonajeRepository : IRepository<Personaje>
    {
        private Context _context;

        public PersonajeRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Personaje> GetList()
        {
            return _context.Personaje
                 .ToList();
        }



        public IEnumerable<Personaje> GetList(PersonajesFilters personajesFilters)
        {
            if(string.IsNullOrEmpty(personajesFilters.Nombre) && string.IsNullOrEmpty(personajesFilters.Edad))
            {
                return GetList();
            }

            var collection = _context.Personaje as IQueryable<Personaje>;

            if (!string.IsNullOrEmpty(personajesFilters.Nombre))
            {
                personajesFilters.Nombre = personajesFilters.Nombre.Trim();
                collection = collection.Where(i => i.Nombre == personajesFilters.Nombre);
            }

            if (!string.IsNullOrEmpty(personajesFilters.Edad))
            {
                personajesFilters.Edad = personajesFilters.Edad.Trim();
                collection = collection.Where(i => i.Edad == personajesFilters.Edad);
            }

            return collection.ToList();

        }

        public Personaje GetListId(int Id)
        {
            return _context.Personaje
                    .Include(i => i.PersonajePeliculaSerie)
                    .ThenInclude(i => i.PeliculaSerie)
                   .FirstOrDefault(i => i.ID == Id);
        }

        public Personaje GetListDetalle(int Id)
        {
            return _context.Personaje
                   .FirstOrDefault(i => i.ID == Id);
        }


        public void Add(Personaje personaje)
        {
            _context.Personaje.Add(personaje);
        }

        public void Updater(Personaje personaje)
        {
            _context.Personaje.Update(personaje);
        }
        public void Delete(Personaje personaje)
        {
            _context.Personaje.Remove(personaje);
        }

        public bool save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Personaje> GetListP(PeliculaSerieFilters peliculaSerieFilters)
        {
            throw new NotImplementedException();
        }
    }
}
