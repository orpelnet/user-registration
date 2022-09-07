using System;
using System.Threading.Tasks;
using UsuariosRegistration.API.User.DTO;

namespace UsuariosRegistration.API.User.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Create(UsuarioDTO UsuariosDTO);
        Task<UsuarioResponse> GetAll();
        Task<UsuarioResponse> Get(int UsuariosId);
        Task<bool> Delete(int id);
        Task<UsuarioDTO> Update(UsuarioDTO Usuarios);
    }
}