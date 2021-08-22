using DisneyApi.Entities;
using DisneyApi.Models;
using DisneyApi.Models.PeliculaSerie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DisneyApi.Services
{
    public class PeliculaSerieRepository : IRepository<PeliculaSerie>
    {

        private Context _context;

        public PeliculaSerieRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<PeliculaSerie> GetList()
        {
            return _context.PeliculaSerie
                .ToList();
        }

        public IEnumerable<PeliculaSerie> GetList(PersonajesFilters personajesFilters)
        {
            throw new NotImplementedException();
        }

        public PeliculaSerie GetListDetalle(int Id)
        {
            return _context.PeliculaSerie
                 .Include(i => i.PersonajePeliculaSerie)
                 .ThenInclude(i => i.Personaje)
                 .FirstOrDefault(a => a.ID == Id);
        }

        public PeliculaSerie GetListId(int Id)
        {
            return _context.PeliculaSerie
               .Include(i => i.PersonajePeliculaSerie)
               .ThenInclude(i => i.Personaje)
               .FirstOrDefault(a => a.ID == Id);
        }

        public void Add(PeliculaSerie peliculaSerie)
        {
            _context.PeliculaSerie.Add(peliculaSerie);
        }


        public void Updater(PeliculaSerie peliculaSerie)
        {
            _context.PeliculaSerie.Update(peliculaSerie);

        }

        public void Delete(PeliculaSerie peliculaSerie)
        {
            _context.PeliculaSerie.Remove(peliculaSerie);
        }

        public bool save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<PeliculaSerie> GetListP(PeliculaSerieFilters peliculaSerieFilters)
        {
            if (string.IsNullOrEmpty(peliculaSerieFilters.Titulo) && string.IsNullOrEmpty(peliculaSerieFilters.CampoOrdenar))
            {
                return GetList();
            }

            var collection = _context.PeliculaSerie as IQueryable<PeliculaSerie>;

            if (!string.IsNullOrEmpty(peliculaSerieFilters.Titulo))
            {
                peliculaSerieFilters.Titulo = peliculaSerieFilters.Titulo.Trim();

                collection = collection.Where(i => i.Titulo == peliculaSerieFilters.Titulo);
            }

            if (!string.IsNullOrEmpty(peliculaSerieFilters.CampoOrdenar))
            {
                var tipoOrden = peliculaSerieFilters.OrdenAscendente ? "ascending" : "descending";
                collection = collection.OrderBy($"{peliculaSerieFilters.CampoOrdenar} {tipoOrden}");
                /*if (peliculaSerieFilters.CampoOrdernar == "FechaDeCreacion")
                {
                    if (peliculaSerieFilters.OrdenAscendente)
                    {
                    collection = collection.OrderBy(x => x.FechaDeCreacion);
                    }
                    else
                    {
                        collection = collection.OrderByDescending(x => x.FechaDeCreacion);

                    }
                }*/
            }




                return collection.ToList();

        }
    }
}
