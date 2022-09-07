using UsuariosRegistration.API.User.DTO;

namespace UsuariosRegistration.API.User.Service
{
    public interface IUsuarioService
    {
        UsuarioDTO Create(UsuarioDTO UsuarioDTO);
        UsuarioResponse GetAll();
        UsuarioDTO Get(int UsuarioId);
        bool Delete(int UsuarioId);
        bool Update(UsuarioDTO Usuario);
    }
}