using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gerente.Core.Excecoes;
using Gerente.Dominio.Entidades;
using Gerente.Infra.Interfaces;
using Gerente.Servico.DTO;
using Gerente.Servico.Interfaces;

namespace Gerente.Servico.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IMapper _mapper;
        private readonly IUserRepositorio _usuarioRepositorio;

        public UsuarioServico(IMapper mapper, IUserRepositorio usuarioRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDTO> Create(UsuarioDTO obj)
        {
            var usuarioExis = await _usuarioRepositorio.GetEmail(obj.Email);
            if (usuarioExis != null)
            {   
                throw new ExecoesDominio("Email já cadastrado para outro Usuário");
            }

            var usuario = _mapper.Map<Usuario>(obj);

            usuario.Validador();

            var criarUsuario = await _usuarioRepositorio.Create(usuario);

            return _mapper.Map<UsuarioDTO>(criarUsuario);
        }

        public async Task<UsuarioDTO> Get(long id)
        {
             var usuario = await _usuarioRepositorio.Get(id);

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> GetEmail(string email)
        {
             var usuario = await _usuarioRepositorio.GetEmail(email);

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<List<UsuarioDTO>> GetList()
        {
            var listUsuarios = await _usuarioRepositorio.GetList();

            return _mapper.Map<List<UsuarioDTO>>(listUsuarios);
        }

        public async Task<List<UsuarioDTO>> GetListEmail(string email)
        {
            var usuarios = await _usuarioRepositorio.GetListEmail(email);

            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task<List<UsuarioDTO>> GetListNome(string nome)
        {
             var usuarios = await _usuarioRepositorio.GetListNome(nome);

            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task Remove(long id)
        {
            await _usuarioRepositorio.Remove(id);
        }

        public async Task<UsuarioDTO> Update(UsuarioDTO obj)
        {
            var usuarioExis = await _usuarioRepositorio.Get(obj.Id);
            if (usuarioExis == null)
            {   
                throw new ExecoesDominio("não existe Usuário com esse Id");
            }

            var usuario = _mapper.Map<Usuario>(obj);

            usuario.Validador();

            var usuarioUpdate = await _usuarioRepositorio.Update(usuario);

            return _mapper.Map<UsuarioDTO>(usuarioUpdate);
        }
    }
}