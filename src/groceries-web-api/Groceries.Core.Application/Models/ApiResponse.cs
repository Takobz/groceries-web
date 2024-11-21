namespace Groceries.Core.Application.Models
{
    public class ApiResponse<T>(T data) where T : class
    {
        public T Data { get; } = data;
    }

    public class ApiResponseCollection<T>(IEnumerable<T> data) where T : class
    {
        public IEnumerable<T> Data { get; } = data;
    }

    public class EmptyApiResponse{ }
}
