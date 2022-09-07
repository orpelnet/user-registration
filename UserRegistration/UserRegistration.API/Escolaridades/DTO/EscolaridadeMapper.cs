using AgileObjects.AgileMapper.Extensions;
using System.Collections.Generic;
using UserRegistration.API.Escolaridades.Domain.Entities;

namespace UserRegistration.API.Escolaridades.DTO
{
    public class EscolaridadeMapper
    {
        public static List<EscolaridadeDTO> ListEscolaridadeToEscolaridade(IEnumerable<Escolaridade> escolaridades)
        {
            var ListEscolaridades = new List<EscolaridadeDTO>();

            escolaridades.ForEach(escolaridade =>
            {
                ListEscolaridades.Add(escolaridade.Map().ToANew<EscolaridadeDTO>());
            });

            return ListEscolaridades;
        }
    }
}