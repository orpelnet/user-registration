using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UserRegistration.API.Escolaridades.Domain.Entities;
using UserRegistration.API.Escolaridades.Domain.Repositories;

namespace UserRegistration.API.Escolaridades.Infrastructure
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        public ICollection<Escolaridade> GetAll()
        {
            using SqlConnection connection = ConnectionManager.OpenConnection();
            return connection.Query<Escolaridade>($@"SELECT * FROM Escolaridade")
                .ToList();
        }
    }
}