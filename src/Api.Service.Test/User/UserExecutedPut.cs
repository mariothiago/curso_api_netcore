namespace Api.Service.Test.User;
public class UserExecutedPut : UserTest
{
    private IUserService? _service;
    private Mock<IUserService>? _serviceMock;

    [Fact(DisplayName = "Executado método Put")]
    public async Task ExecutadoMetodoPut()
    {
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
        _service = _serviceMock.Object;

        var resultCreate = await _service.Post(userDtoCreate);
        Assert.NotNull(resultCreate);
        Assert.Equal(NomeUsuario, resultCreate.Name);
        Assert.Equal(EmailUsuario, resultCreate.Email);

        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
        _service = _serviceMock.Object;

        var resultUpdate = await _service.Put(userDtoUpdate);
        Assert.NotNull(resultUpdate);
        Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
        Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
    }
}
