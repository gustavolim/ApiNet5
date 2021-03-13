using System.Collections.Generic;
using System.Threading.Tasks;
using Gerente.Dominio.Entidades;

namespace Gerente.Infra.Interfaces
{
    public interface IUserRepositorio : IBaseRepositorio<Usuario>
    {
         Task<Usuario> GetEmail(string email);
         Task<List<Usuario>> GetListEmail(string email);
         Task<List<Usuario>> GetListNome(string nome);
    }
}