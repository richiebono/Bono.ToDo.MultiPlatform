using Bono.ToDo.Domain.Validations;

namespace Bono.ToDo.Domain.Interfaces.Validations
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
