namespace ExamCore.Shared.Exceptions
{
    public class DuplicateValueException : Exception
    {
        public bool PassErrorToClient { get; set; }

        public DuplicateValueException(dynamic name, string massage, bool passToClient = true)
        : base($"This \"{name}\" ({massage}) is already exist.")
        {
            PassErrorToClient = passToClient;
        }
    }
}