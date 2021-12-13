using System;
using System.Threading.Tasks;
using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;

namespace Api.Services.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseUser = new LoginDto();
            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                return await _repository.FindByLogin(login.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
