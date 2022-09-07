using System;
using System.Threading.Tasks;
using UsuariosRegistration.API.User.DTO;

namespace UsuariosRegistration.API.User.Service
{
    public class UsuarioService : IUsuarioService
    {
        public Task<UsuarioDTO> Create(UsuarioDTO UsuariosDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Get(int UsuariosId)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> Update(UsuarioDTO Usuarios)
        {
            throw new NotImplementedException();
        }
    }
}