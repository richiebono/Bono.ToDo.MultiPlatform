using Bono.ToDo.Domain.Validations;

namespace Bono.ToDo.Domain.Interfaces.Validations
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
