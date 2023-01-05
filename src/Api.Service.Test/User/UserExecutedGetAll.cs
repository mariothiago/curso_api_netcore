namespace Api.Service.Test.User;

public class UserExecutedGetAll : UserTest
{
    private IUserService? _service;
    private Mock<IUserService>? _serviceMock;

    [Fact(DisplayName ="Executado método GetALl")]
    public async Task ExecutadoMetodoGetALl()
    {
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
        _service = _serviceMock.Object;

        var result = await _service.GetAll();
        Assert.NotNull(result);
        Assert.True(result.Count() == 10);

        var listResult = new List<UserDto>();
        _serviceMock = new Mock<IUserService>();
        _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listResult.AsEnumerable);
        _service = _serviceMock.Object;

        var resultEmpty = await _service.GetAll();
        Assert.Empty(resultEmpty);
        Assert.True(resultEmpty.Count() == 0);
    }
}
