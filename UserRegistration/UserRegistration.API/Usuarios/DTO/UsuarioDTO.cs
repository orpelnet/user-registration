using System;
using UserRegistration.API.Escolaridades.Domain.Entities;
using UserRegistration.API.Usuarios.Domain.Entities;

namespace UsuariosRegistration.API.Usuarios.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public int HistoricoEscolarId { get; set; }
        public virtual Escolaridade Escolaridade { get; set; }
        public virtual HistoricoEscolar HistoricoEscolar { get; set; }
        public string EscolaridadeDescricao { get; set; }
    }
}