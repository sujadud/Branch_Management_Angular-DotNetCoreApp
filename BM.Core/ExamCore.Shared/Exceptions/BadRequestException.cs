namespace ExamCore.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public BadRequestException(string message, bool passToClient = true)
            : base(message)
        {
            PassErrorToClient = passToClient;
        }
    }
}