using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UserRegistration.API;
using UserRegistration.API.Escolaridades.Domain.Entities;
using UserRegistration.API.Usuarios.Domain.Entities;
using UsuariosRegistration.API.Usuarios.Domain.Entities;
using UsuariosRegistration.API.Usuarios.Domain.Repositories;

namespace UsuariosRegistration.API.Usuarios.Infrastructure
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario Create(Usuario usuario)
        {
            SqlTransaction objTransaction = null;

            using (SqlConnection connection = ConnectionManager.OpenConnection())
            {
                objTransaction = connection.BeginTransaction();

                string sqlShoppingCart = @"INSERT INTO Usuarios (Nome,Sobrenome,Email,DataNascimento,EscolaridadeId,HistoricoEscolarId) VALUES
                                           (@Nome,@Sobrenome,@Email,@DataNascimento,@EscolaridadeId,@HistoricoEscolarId)
                                           SELECT SCOPE_IDENTITY()";
                try
                {
                    using (SqlCommand command = new SqlCommand(sqlShoppingCart, connection))
                    {
                        command.Transaction = objTransaction;
                        command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = usuario.Nome;
                        command.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = usuario.Sobrenome;
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
                        command.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = usuario.DataNascimento;
                        command.Parameters.Add("@EscolaridadeId", SqlDbType.Int).Value = usuario.EscolaridadeId;
                        command.Parameters.Add("@HistoricoEscolarId", SqlDbType.Int).Value = usuario.HistoricoEscolarId;
                        usuario.Id = Convert.ToInt32(command.ExecuteScalar());
                    }

                    objTransaction.Commit();
                }
                catch
                {
                    objTransaction.Rollback();
                    throw;
                }
            }

            return usuario;
        }

        public bool Delete(int UsuarioId)
        {
            int totalRows = 0;
            string sql = @"DELETE FROM Usuarios WHERE Id = @UsuarioId";

            using (SqlConnection connection = ConnectionManager.OpenConnection())
            {
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                totalRows = Convert.ToInt32(command.ExecuteNonQuery());
            }

            return totalRows == 1;
        }

        public Usuario Get(int UsuarioId)
        {
            string sql = @"SELECT 
                               u.Id,
                               u.Nome
                               ,u.Sobrenome
                               ,u.Email
                               ,u.DataNascimento
                               ,u.EscolaridadeId
                               ,u.HistoricoEscolarId
                               ,e.Id                               
                               ,e.Descricao
                               ,h.Id                               
                               ,h.Nome
                               ,h.Formato 
                           FROM usuarios u
                           INNER JOIN Escolaridade e on u.EscolaridadeId = e.Id
                           INNER Join HistoricoEscolar h on u.HistoricoEscolarId = h.Id
                           WHERE u.Id = @UsuarioId";

            Usuario usuario = null;

            using SqlConnection connection = ConnectionManager.OpenConnection();
            connection.Query<Usuario, Escolaridade, HistoricoEscolar, Usuario>(sql, (u, escolaridade, historicoEscolar) =>
            {
                usuario ??= u;
                usuario.Escolaridade = escolaridade;
                usuario.HistoricoEscolar = historicoEscolar;

                return usuario;
            },
            new { UsuarioId },
            splitOn: "id, id, id");
            return usuario;
        }

        public ICollection<Usuario> GetAll()
        {
            string sql = @"SELECT 
                               u.Id,
                               u.Nome
                               ,u.Sobrenome
                               ,u.Email
                               ,u.DataNascimento
                               ,u.EscolaridadeId
                               ,u.HistoricoEscolarId
                               ,e.Id                               
                               ,e.Descricao
                               ,h.Id                               
                               ,h.Nome
                               ,h.Formato 
                           FROM usuarios u
                           INNER JOIN Escolaridade e on u.EscolaridadeId = e.Id
                           INNER Join HistoricoEscolar h on u.HistoricoEscolarId = h.Id";

            var usuarios = new List<Usuario>();

            using SqlConnection connection = ConnectionManager.OpenConnection();
            connection.Query<Usuario, Escolaridade, HistoricoEscolar, Usuario>(sql, (usuario, escolaridade, historicoEscolar) =>
            {
                usuario ??= usuario;
                usuario.Escolaridade = escolaridade;
                usuario.HistoricoEscolar = historicoEscolar;

                usuarios.Add(usuario);

                return usuario;
            },
            splitOn: "id, id, id");
            return usuarios;
        }

        public bool ThereAlreadyUserWithEmail(string email)
        {
            using SqlConnection connection = ConnectionManager.OpenConnection();
            return connection.Query<Usuario>($@"SELECT 1 FROM Usuarios u WHERE u.Email = '{email}'").Any();
        }

        public bool Update(Usuario usuario)
        {
            using SqlConnection connection = ConnectionManager.OpenConnection();
            string sql = $@"UPDATE Usuarios
                                SET Nome=@Nome
                                ,Sobrenome=@Sobrenome
                                ,Email=@Email
                                ,DataNascimento=@DataNascimento
                                ,EscolaridadeId=@EscolaridadeId
                                ,HistoricoEscolarId=@HistoricoEscolarId
                                WHERE Id=@userId";

            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = usuario.Nome;
            command.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = usuario.Sobrenome;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
            command.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = usuario.DataNascimento;
            command.Parameters.Add("@EscolaridadeId", SqlDbType.Int).Value = usuario.EscolaridadeId;
            command.Parameters.Add("@HistoricoEscolarId", SqlDbType.Int).Value = usuario.HistoricoEscolarId;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = usuario.Id;

            int rowsAffected = Convert.ToInt32(command.ExecuteNonQuery());
            return rowsAffected == 1;
        }
    }
}