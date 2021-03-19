using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerente.Core.Excecoes;
using Gerente.Dominio.Validadores;

namespace Gerente.Dominio.Entidades
{
    public class Usuario : Base
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        //EF
        protected Usuario()
        {
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            _erros = new List<string>();
        }

        public void MudarNome(string nome)
        {
            Nome = nome;
            Validador();
        }

        public void MudarSenha(string senha)
        {
            Senha = senha;
            Validador();
        }

        public void MudarEmai(string email)
        {
            Email = email;
            Validador();
        }
        public override bool Validador()
        {
            var validacao = new UsuarioValidador();
            var resultValidacao = validacao.Validate(this);

            if (!resultValidacao.IsValid)
            {
                foreach (var erro in resultValidacao.Errors)
                {
                    _erros.Add(erro.ErrorMessage);
                }

                //throw new Exception("Campos inválidos" + _erros[0]);
                throw new ExecoesDominio("Campos inválidos" + _erros);
            }

            return true;
        }
    }
}