using ApiLogin.Application.Services;
using ApiLogin.Comunication.Request;
using ApiLogin.Comunication.Response;
using ApiLogin.Domain.Entities;
using ApiLogin.Domain.Repository;
using ApiLogin.Exception.Usuario;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public class Usuario : IUserRegistro
    {
        private readonly IUSerRepository _user;
        private readonly IMapper _map;
        private readonly IUnitiOfWork _unit;
        private readonly ITokenGerado _tkn;
        private readonly CryptSenha _password;
        public Usuario(IUSerRepository uSerRepository, IMapper mapper, IUnitiOfWork work, ITokenGerado token, CryptSenha password)
        {
            _user = uSerRepository;
            _map = mapper;
            _unit = work;
            _tkn = token;
            _password = password;
        }
        public async Task<UsuarioResponse> RegistrarUsuario(UsuarioRequest user)
        {
            await ValidarUsuario(user);
            var usuario = _map.Map<ApiLogin.Domain.Entities.Usuario>(user);
            usuario.senha = _password.EncrptSenha(user.senha);
            usuario.TokenUsuario = _tkn.GerarToken(Guid.NewGuid().ToString());
            await _user.Adicionar(usuario);
            await _unit.Salvar();

            return new UsuarioResponse
            {

                nome = usuario.nome,
                token=usuario.TokenUsuario

            };

        }
        public async Task ValidarUsuario(UsuarioRequest usuario)
        {
            var validar_usuario = new ValidarUsuario();
            var response_usuario = validar_usuario.Validate(usuario);
            var usuario_cadastrado = await _user.EmailJaCadastrado(usuario.email);

            if (usuario_cadastrado)
            {
                response_usuario.Errors.Add(new FluentValidation.Results.ValidationFailure("email", UserException.email_existente));
            }

            if (response_usuario.IsValid == false)
            {
                var lista_usuario = response_usuario.Errors.Select(s => s.ErrorMessage).ToList();
                throw new UsuarioOnException(lista_usuario);

            }

        }
    }
}
