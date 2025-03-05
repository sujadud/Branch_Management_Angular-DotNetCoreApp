namespace ExamCore.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public NotFoundException(string message, bool passToClient = true) : base(message)
        {
            PassErrorToClient = passToClient;
        }

        public NotFoundException(string name, object key, bool passToClient = true)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            PassErrorToClient = passToClient;
        }
    }
}