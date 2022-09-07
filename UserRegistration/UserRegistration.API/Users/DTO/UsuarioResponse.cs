using System.Collections.Generic;

namespace UsuariosRegistration.API.User.DTO
{
    public class UsuarioResponse
    {
        public UsuarioResponse()
        {
            Usuarioss = new List<UsuarioDTO>();
        }

        public List<UsuarioDTO> Usuarioss { get; set; }
    }
}