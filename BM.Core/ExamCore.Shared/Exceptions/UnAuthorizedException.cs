namespace ExamCore.Shared.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public UnAuthorizedException(string message, bool passToClient = true)
            : base(message)
        {
            PassErrorToClient = passToClient;
        }
    }
}