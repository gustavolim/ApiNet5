using System.Collections.Generic;
using System.Threading.Tasks;
using Gerente.Servico.DTO;

namespace Gerente.Servico.Interfaces
{
    public interface IUsuarioServico
    {
        Task<UsuarioDTO> Create(UsuarioDTO obj);
         Task<UsuarioDTO> Update(UsuarioDTO obj);
         Task Remove(long id);
         Task<UsuarioDTO> Get(long id);
         Task<List<UsuarioDTO>> GetList();
         Task<UsuarioDTO> GetEmail(string email);
         Task<List<UsuarioDTO>> GetListEmail(string email);
         Task<List<UsuarioDTO>> GetListNome(string nome);
         
    }
}