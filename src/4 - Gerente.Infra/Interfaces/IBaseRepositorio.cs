using System.Collections.Generic;
using System.Threading.Tasks;
using Gerente.Dominio.Entidades;

namespace Gerente.Infra.Interfaces
{
    public interface IBaseRepositorio<T> where T : Base
    {
         Task<T> Create(T obj);
         Task<T> Update(T obj);
         Task Remove(long id);
         Task<T> Get(long id);
         Task<List<T>> GetList();

    }
}