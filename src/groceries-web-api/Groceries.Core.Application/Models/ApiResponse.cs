namespace Groceries.Core.Application.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }

    public class EmptyApiResponse{ }
}
