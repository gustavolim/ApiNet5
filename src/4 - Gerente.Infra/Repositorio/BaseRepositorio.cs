using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerente.Dominio.Entidades;
using Gerente.Infra.Contexto;
using Gerente.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gerente.Infra.Repositorio
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : Base
    {
      private readonly GerenteContexto _contexto;

        public BaseRepositorio(GerenteContexto contexto)
        {
            _contexto = contexto;
        }

        public virtual async Task<T> Create(T obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _contexto
            .Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

             return obj;
        }

        public async Task<List<T>> GetList()
        {
           var obj = await _contexto
            .Set<T>()
            .AsNoTracking()
            .ToListAsync();

             return obj;
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _contexto.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Update(T obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;

            await _contexto.SaveChangesAsync();

            return obj;
        }
    }
}