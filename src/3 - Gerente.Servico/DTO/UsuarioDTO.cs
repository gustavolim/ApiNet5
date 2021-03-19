namespace Gerente.Servico.DTO
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public UsuarioDTO()
        {
            
        }

        public UsuarioDTO(long id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}