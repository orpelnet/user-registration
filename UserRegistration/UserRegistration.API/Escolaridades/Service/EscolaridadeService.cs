using System.Collections.Generic;
using UserRegistration.API.Escolaridades.Domain.Repositories;
using UserRegistration.API.Escolaridades.DTO;

namespace UserRegistration.API.Escolaridades.Service
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private readonly IEscolaridadeRepository escolaridadeRepository;

        public EscolaridadeService(IEscolaridadeRepository escolaridadeRepository)
        {
            this.escolaridadeRepository = escolaridadeRepository;
        }

        public List<EscolaridadeDTO> GetAll()
        {
            var escolarirades = escolaridadeRepository.GetAll();

            return EscolaridadeMapper.ListEscolaridadeToEscolaridade(escolarirades);
        }
    }
}