using System.Collections.Generic;
using UserRegistration.API.Escolaridades.Domain.Entities;

namespace UserRegistration.API.Escolaridades.Domain.Repositories
{
    public interface IEscolaridadeRepository
    {
        ICollection<Escolaridade> GetAll();
    }
}