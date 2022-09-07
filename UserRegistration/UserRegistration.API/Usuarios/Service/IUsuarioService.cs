using System.Collections.Generic;
using UsuariosRegistration.API.Usuarios.DTO;

namespace UsuariosRegistration.API.Usuarios.Service
{
    public interface IUsuarioService
    {
        UsuarioDTO Create(UsuarioDTO UsuarioDTO);
        List<UsuarioDTO> GetAll();
        UsuarioDTO Get(int UsuarioId);
        bool Delete(int UsuarioId);
        bool Update(UsuarioDTO Usuario);
    }
}