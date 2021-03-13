using System.Collections.Generic;
using System.Threading.Tasks;
using Gerente.Dominio.Entidades;
using Gerente.Infra.Contexto;
using Gerente.Infra.Interfaces;

namespace Gerente.Infra.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUserRepositorio
    {
        private readonly GerenteContexto _contexto;
        public UsuarioRepositorio(GerenteContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Task<Usuario> GetEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Usuario>> GetListEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Usuario>> GetListNome(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}