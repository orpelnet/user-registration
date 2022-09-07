using System.Collections.Generic;
using UsuariosRegistration.API.User.Domain.Entities;

namespace UsuariosRegistration.API.User.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario Usuarios);
        ICollection<Usuario> GetAll();
        Usuario Get(int UsuarioId);
        bool Update(Usuario Usuario);
        bool Delete(int UsuarioId);
        bool ThereAlreadyUserWithEmail(string email);
    }
}