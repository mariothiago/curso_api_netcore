using Api.Domain.DTOs;

namespace Api.Service.Test.Login;
public class ExecutedLoginTest
{
    private ILoginService? _service;
    private Mock<ILoginService>? _serviceMock;

    [Fact(DisplayName = "Executado método de Login")]
    public async Task ExecutadoMetodoLogin()
    {
        var email = Faker.Internet.Email();

        var objetoRetornado = new
        {
            authenticated = true,
            created = DateTime.Now,
            expiration = DateTimeOffset.Now.AddHours(2),
            acessToken = Guid.NewGuid(),
            userName = email,
            name = Faker.Name.FullName(),
            message = "Usuário logado com sucesso"
        };

        var loginDto = new LoginDto
        {
            Email = email
        };

        _serviceMock = new Mock<ILoginService>();
        _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetornado);
        _service = _serviceMock.Object;

        var result = await _service.FindByLogin(loginDto);
        Assert.NotNull(result);
        
    }
}
