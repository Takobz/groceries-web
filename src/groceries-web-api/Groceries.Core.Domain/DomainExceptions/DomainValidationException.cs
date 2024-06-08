namespace Groceries.Core.Domain.DomainExceptions
{
    public class DomainValidationException(string message) : Exception(message)
    {
    }
}