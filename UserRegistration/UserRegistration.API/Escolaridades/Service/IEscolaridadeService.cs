using System.Collections.Generic;
using UserRegistration.API.Escolaridades.DTO;

namespace UserRegistration.API.Escolaridades.Service
{
    public interface IEscolaridadeService
    {
        List<EscolaridadeDTO> GetAll();
    }
}