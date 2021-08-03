using DisneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Services
{
    public interface IRepository <TEntity>
    {
        IEnumerable<TEntity> GetList();

        IEnumerable<TEntity> GetList(PersonajesFilters personajesFilters);

        TEntity GetListId(int Id);

        TEntity GetListDetalle(int Id);

        void Add(TEntity TEntity);
        void Updater(TEntity TEntity);

        void Delete(TEntity TEntity);

        bool save();
    }
}
