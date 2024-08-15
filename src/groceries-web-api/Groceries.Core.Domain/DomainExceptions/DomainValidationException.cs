namespace Groceries.Core.Domain.DomainExceptions
{
    /// <summary>
    /// Exception Indicating Bad/Invalid Data 
    /// </summary>
    /// <param name="message"></param>
    public class DomainValidationException(string message) : Exception(message)
    {
    }
}