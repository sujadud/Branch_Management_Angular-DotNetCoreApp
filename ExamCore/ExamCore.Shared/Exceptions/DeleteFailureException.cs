namespace ExamCore.Shared.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public DeleteFailureException(string name, object key, string message, bool passToClient = true)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
            PassErrorToClient = passToClient;
        }
    }
}