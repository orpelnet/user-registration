using AgileObjects.AgileMapper.Extensions;
using System.Collections.Generic;
using UsuariosRegistration.API.User.Domain.Entities;
using UsuariosRegistration.API.User.DTO;

namespace UserRegistration.API.Users.DTO
{
    public class UsuarioMapper
    {
        public static UsuarioResponse ListUsuariosToUsuarioResponse(IEnumerable<Usuario> usuarios)
        {
            var usuarioResponse = new UsuarioResponse();
            
            usuarios.ForEach(usuario =>
            {
                usuarioResponse.Usuarios.Add(usuario.Map().ToANew<UsuarioDTO>());
            });

            return usuarioResponse;
        }

        public static UsuarioDTO UsuarioToUsuarioDTO(Usuario usuario)
        {
            return usuario.Map().ToANew<UsuarioDTO>();
        }

        public static Usuario UsuarioDTOToUsuario(UsuarioDTO usuarioDTO)
        {
            return usuarioDTO.Map().ToANew<Usuario>();
        }
    }
}