using System;
using UserRegistration.API.Users.DTO;
using UsuariosRegistration.API.User.Domain.Repositories;
using UsuariosRegistration.API.User.DTO;

namespace UsuariosRegistration.API.User.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public UsuarioDTO Create(UsuarioDTO UsuarioDTO)
        {
            MustContainEmail(UsuarioDTO.Email);
            ThereAlreadyUserWithEmail(UsuarioDTO.Email);
            MustContainDataNascimento(UsuarioDTO.DataNascimento);
            DateMustBeMayThanToday(UsuarioDTO.DataNascimento);
            InvalidEducation(UsuarioDTO.EscolaridadeDescricao);

            var usuario = usuarioRepository.Create(UsuarioMapper.UsuarioDTOToUsuario(UsuarioDTO));

            return UsuarioMapper.UsuarioToUsuarioDTO(usuario);
        }

        public bool Delete(int UsuarioId)
        {
            MustShouldBeUser(UsuarioId);
            return usuarioRepository.Delete(UsuarioId);
        }

        public UsuarioDTO Get(int UsuarioId)
        {
            var usuario = usuarioRepository.Get(UsuarioId);

            return UsuarioMapper.UsuarioToUsuarioDTO(usuario);
        }

        public UsuarioResponse GetAll()
        {
            var usuarios = usuarioRepository.GetAll();

            return UsuarioMapper.ListUsuariosToUsuarioResponse(usuarios);
        }

        public bool Update(UsuarioDTO UsuarioDTO)
        {
            MustShouldBeUser(UsuarioDTO.Id);
            return usuarioRepository.Update(UsuarioMapper.UsuarioDTOToUsuario(UsuarioDTO));
        }

        private bool MustShouldBeUser(int UsuarioId)
        {
            var usuario = usuarioRepository.Get(UsuarioId);
            if (usuario is null) throw new ArgumentException("Usuário não encontrado!");

            return true;
        }

        private static bool MustContainEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email é obrigatório");
            return true;
        }

        private bool ThereAlreadyUserWithEmail(string email)
        {
            var usuario = usuarioRepository.ThereAlreadyUserWithEmail(email);
            if (usuario) throw new ArgumentException("Já exiate um usuário com esse email");

            return true;
        }

        private static bool MustContainDataNascimento(DateTime dataNascimento)
        {
            if (string.IsNullOrEmpty(dataNascimento.ToString())) throw new ArgumentException("Data de nascimento é obrigatório");
            return true;
        }

        private static bool DateMustBeMayThanToday(DateTime dataNascimento)
        { 
            if(dataNascimento >= DateTime.Now) throw new ArgumentException("A data de nascimento não pode ser maior que hoje.");
            
            return true;
        }

        private static bool InvalidEducation(string escolaridadeDescricao)
        {
            if (escolaridadeDescricao == "Infantil" || escolaridadeDescricao == "Fundamental" || escolaridadeDescricao == "Médio" || escolaridadeDescricao == "Superior")
                return true;

            throw new ArgumentException("Escolaridade inválida.");
        }
    }
}