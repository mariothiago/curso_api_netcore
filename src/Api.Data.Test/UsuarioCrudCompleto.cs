using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;
public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
{
    private ServiceProvider _serviceProvider; 
    public UsuarioCrudCompleto(DbTeste dbTeste)
    {
        _serviceProvider = dbTeste.serviceProvider;
    }

    [Fact(DisplayName = "CRUD de usuário")]
    [Trait("CRUD", "UserEntity")]
    public async Task RealizaCRUD()
    {
        using(var context = _serviceProvider.GetService<MyContext>())
        {
            #region create 
            UserImplementation _repository = new UserImplementation(context);
            UserEntity entity = new()
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName()
            };

            var registro = await _repository.InsertAsync(entity);
            Assert.NotNull(registro);
            Assert.Equal(entity.Email, registro.Email);
            Assert.False(registro.Id == Guid.Empty);
            #endregion

            #region Update
            entity.Name = Faker.Name.First();

            var registroAtualizado = await _repository.UpdateAsync(entity);
            Assert.NotNull(registroAtualizado);
            Assert.Equal(entity.Email, registroAtualizado.Email);
            Assert.Equal(entity.Name, registroAtualizado.Name);

            #endregion

            #region Get
            var registroExiste = await _repository.SelectAsync(registroAtualizado.Id);
            Assert.NotNull(registroExiste);
            #endregion

            #region GetAll
            var todosRegistros = await _repository.SelectAsync();
            Assert.NotNull(todosRegistros);
            Assert.True(todosRegistros.Count() > 0);
            #endregion

            #region Delete
            var removeu = await _repository.DeleteAsync(registroExiste.Id);
            Assert.True(removeu);
            #endregion

            var usuarioPadrao = await _repository.FindByLogin("mario.thiago247@gmail.com");
            Assert.NotNull(usuarioPadrao);
        }
    }
}