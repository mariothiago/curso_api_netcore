using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Test.AutoMapper;

public class UserMapper : BaseTestService
{
    [Fact(DisplayName = "É possível mapear os modelos")]
    public void MapearModelos()
    {
        var model = new UserModel
        {
            Id = Guid.NewGuid(),
            Name = Faker.Name.FullName(),
            Email = Faker.Internet.Email(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var listaEntity = new List<UserEntity>();

        for (int i = 0; i < 5; i++)
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            listaEntity.Add(user);
        }

        // Model => Entity
        var entity = Mapper.Map<UserEntity>(model);
        Assert.Equal(entity.Id, model.Id);
        Assert.Equal(entity.Name, model.Name);
        Assert.Equal(entity.Email, model.Email);
        Assert.Equal(entity.CreateAt, model.CreatedAt);
        Assert.Equal(entity.UpdateAt, model.UpdatedAt);

        // Entity => Dto
        var userDto = Mapper.Map<UserDto>(entity);
        Assert.Equal(userDto.Id, entity.Id);
        Assert.Equal(userDto.Name, entity.Name);
        Assert.Equal(userDto.Email, entity.Email);
        Assert.Equal(userDto.CreateAt, entity.CreateAt);

        var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
        Assert.True(listaDto.Count() == listaEntity.Count());
        for (int i = 0; i < listaDto.Count(); i++)
        {
            Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
            Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
            Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
            Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
        }

        var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
        Assert.Equal(userDtoCreateResult.Id, entity.Id);
        Assert.Equal(userDtoCreateResult.Name, entity.Name);
        Assert.Equal(userDtoCreateResult.Email, entity.Email);
        Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

        var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
        Assert.Equal(userDtoUpdateResult.Id, entity.Id);
        Assert.Equal(userDtoUpdateResult.Name, entity.Name);
        Assert.Equal(userDtoUpdateResult.Email, entity.Email);
        Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

        // Dto => Model
        var userModel = Mapper.Map<UserModel>(userDto);
        Assert.Equal(userModel.Id, userDto.Id);
        Assert.Equal(userModel.Name, userDto.Name);
        Assert.Equal(userModel.Email, userDto.Email);
        Assert.Equal(userModel.CreatedAt, userDto.CreateAt);

        var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
        Assert.Equal(userDtoCreate.Name, userModel.Name);
        Assert.Equal(userDtoCreate.Email, userModel.Email);

        var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
        Assert.Equal(userDtoUpdate.Id, userModel.Id);
        Assert.Equal(userDtoCreate.Name, userModel.Name);
        Assert.Equal(userDtoCreate.Email, userModel.Email);
    }
}
