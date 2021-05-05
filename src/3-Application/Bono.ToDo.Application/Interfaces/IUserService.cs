using Bono.ToDo.Application.ViewModels;
using Bono.ToDo.Domain.Validations;

namespace Bono.ToDo.Application.Interfaces
{
    public interface IUserService : IService<UserViewModel>
    {
        ValidationResult Authenticate(UserAuthenticateRequestViewModel user);
    }
}
