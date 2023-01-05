using Api.Domain.DTOs.User;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string? NomeUsuario { get; set; }
        public static string? EmailUsuario { get; set; }
        public static string? NomeUsuarioAlterado { get; set; }
        public static string? EmailUsuarioAlterado { get; set; }

        public static Guid IdUsuario { get; set; }

        public List<UserDto> listaUserDto = new();

        public UserDto userDto = new();
        public UserDtoCreate userDtoCreate = new();
        public UserDtoCreateResult userDtoCreateResult = new();
        public UserDtoUpdate userDtoUpdate = new();
        public UserDtoUpdateResult userDtoUpdateResult = new();

        public UserTest()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for(int i = 0; i < 10; i++){
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.Now,
                    Email = Faker.Internet.Email()
                };

                listaUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = IdUsuario,
                Email = EmailUsuario,
                Name = NomeUsuario
            };

            userDtoCreate = new UserDtoCreate
            {
                Email = EmailUsuario,
                Name = NomeUsuario
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = IdUsuario,
                Email = EmailUsuario,
                Name = NomeUsuario,
                CreateAt = DateTime.Now
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Email = EmailUsuarioAlterado,
                Name = NomeUsuarioAlterado,
                Id = IdUsuario
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Email = EmailUsuarioAlterado,
                Name = NomeUsuarioAlterado,
                Id = IdUsuario,
                UpdateAt = DateTime.Now
            };
        }
    }
}