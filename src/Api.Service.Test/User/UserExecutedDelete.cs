namespace Api.Service.Test.User;
public class UserExecutedDelete : UserTest
{
    private IUserService? _service;
    private Mock<IUserService>? _serviceMock;

    [Fact(DisplayName = "Executado método Delete")]
    public async Task ExecutadoMetodoDelete()
    {
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
        _service = _serviceMock.Object;

        var result = await _service.Delete(IdUsuario);
        Assert.True(result);

        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
        _service = _serviceMock.Object;

        result = await _service.Delete(Guid.NewGuid());
        Assert.False(result);
    }
}
