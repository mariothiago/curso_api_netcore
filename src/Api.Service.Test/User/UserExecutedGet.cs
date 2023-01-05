namespace Api.Service.Test.User;

    public class UserExecutedGet : UserTest
{
    private IUserService? _service;
    private Mock<IUserService>? _serviceMock;

    [Fact(DisplayName = "É possível executar o método GET.")]
    public async Task ExecutaMetodoGet()
    {
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
        _service = _serviceMock.Object;

        var result = await _service.Get(IdUsuario);
        Assert.NotNull(result);
        Assert.True(result.Id == IdUsuario);
        Assert.Equal(NomeUsuario, result.Name);

        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
            .Returns(Task.FromResult((UserDto)null));

        _service = _serviceMock.Object;
        var record = await _service.Get(IdUsuario);

        Assert.Null(record);
    }
}
