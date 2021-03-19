using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerente.Dominio.Entidades;
using Gerente.Infra.Contexto;
using Gerente.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gerente.Infra.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUserRepositorio
    {
        private readonly GerenteContexto _contexto;
        public UsuarioRepositorio(GerenteContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> GetEmail(string email)
        {
            var user = await _contexto.Usuarios
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()
                                    )
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<Usuario>> GetListEmail(string email)
        {
            var allUsers = await _contexto.Usuarios
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }

        public async Task<List<Usuario>> GetListNome(string nome)
        {
            var allUsers = await _contexto.Usuarios
                                   .Where
                                   (
                                        x =>
                                            x.Nome.ToLower().Contains(nome.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }
    }
}