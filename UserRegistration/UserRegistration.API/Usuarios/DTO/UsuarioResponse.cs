using System.Collections.Generic;

namespace UsuariosRegistration.API.Usuarios.DTO
{
    public class UsuarioResponse
    {
        public UsuarioResponse()
        {
            Usuarios = new List<UsuarioDTO>();
        }

        public List<UsuarioDTO> Usuarios { get; set; }
    }
}