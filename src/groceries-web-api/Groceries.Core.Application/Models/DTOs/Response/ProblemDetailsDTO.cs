namespace Groceries.Core.Application.Extensions
{
    public class ProblemDetailsDTO(string type, string title, int status, string details)
    {

        /// <summary>
        /// rfc link detailing the HTTP status code
        /// </summary>
        public string Type { get; private set; } = type;
        /// <summary>
        /// Title of the problem
        /// </summary>
        public string Title { get; private set; } = title;
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Status { get; private set; } = status;
        /// <summary>
        /// Details of the problem
        /// </summary>
        public string Details { get; private set; } = details;
    }
}