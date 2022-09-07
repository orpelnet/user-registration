using AgileObjects.AgileMapper.Extensions;
using System.Collections.Generic;
using UsuariosRegistration.API.Usuarios.Domain.Entities;
using UsuariosRegistration.API.Usuarios.DTO;

namespace UserRegistration.API.Users.DTO
{
    public class UsuarioMapper
    {
        public static List<UsuarioDTO> ListUsuariosToUsuarioResponse(IEnumerable<Usuario> usuarios)
        {
            var ListUsuarios = new List<UsuarioDTO>();
            
            usuarios.ForEach(usuario =>
            {
                ListUsuarios.Add(usuario.Map().ToANew<UsuarioDTO>());
            });

            return ListUsuarios;
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