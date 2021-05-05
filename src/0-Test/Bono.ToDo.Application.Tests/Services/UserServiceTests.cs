using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bono.ToDo.Application.AutoMapper;
using Bono.ToDo.Application.Services;
using Bono.ToDo.Application.ViewModels;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces;
using Xunit;
using Bono.ToDo.Domain.Interfaces.Repository;
using ValidationResult = Bono.ToDo.Domain.Validations.ValidationResult;
using System.Linq;
using Bono.ToDo.Infrastructure.Utils;

namespace Bono.ToDo.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object, new ValidationResult(), new Security());
        }

        #region ValidatingSendingID

        [Fact]
        public void PostSendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetByIdSendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void PutSendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void DeleteSendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void AuthenticateSendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required.", exception.Message);
        }

        #endregion

        #region ValidatingCorrectObject

        [Fact]
        public void PostSendingValidObject()
        {
            var result = userService.Post(new UserViewModel { FirstName = "Richard Bono", Email = "richiebono@gmail.com", Password = "bono@teste" });
            Assert.True(result.IsValid);
        }

        [Fact]
        public void GetValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<User> users = new List<User>();
            users.Add(new User("Richard Bono", "admin@123", "Richard Bono", "Oliveira", "123.456.456-56", "richiebono@gmail.com", "+55 11-98547-3851"));
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetAll()).Returns(users);
            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var autoMapperProfile = new AutoMapperSetup();
            var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
            IMapper mapper = new Mapper(configuration);
            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            
            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = userService.GetAll();
            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count() > 0);
        }

        #endregion

        #region ValidatingRequiredFields

        [Fact]
        public void PostSendingInvalidObject()
        {
            UserViewModel user = new UserViewModel();

            var exception = Assert.Throws<ValidationException>(() => userService.Post(user));
            Assert.Equal("The sent object was empty.", exception.Message);
        }

        #endregion
    }
}
