namespace Api.Service.Test.User;

public class UserExecutedPost : UserTest
{
    private IUserService? _service;
    private Mock<IUserService>? _serviceMock;

    [Fact(DisplayName ="Executado método Post")]
    public async Task ExecutadoMetodoPost()
    {
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
        _service = _serviceMock.Object;

        var result = await _service.Post(userDtoCreate);
        Assert.NotNull(result);
        Assert.Equal(NomeUsuario, result.Name);
        Assert.Equal(EmailUsuario, result.Email);
    }
}
