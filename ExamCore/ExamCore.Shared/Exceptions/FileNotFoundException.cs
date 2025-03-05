namespace ExamCore.Shared.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public FileNotFoundException(string message, bool passToClient = true) : base(message)
        {
            PassErrorToClient = passToClient;
        }

        public FileNotFoundException(string name, object key, bool passToClient = true)
            : base($"File Name \"{name}\" was not found.")
        {
            PassErrorToClient = passToClient;
        }
    }
}