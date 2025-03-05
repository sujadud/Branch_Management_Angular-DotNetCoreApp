using System.Text.Json.Serialization;

namespace ExamCore.Shared.Models
{
    public class ResponseMessage<T>
    {
        public ResponseMessage(T result)
        {
            Result = result;
        }

        public ResponseMessage()
        {

        }

        private string _errorMessage;

        public T Result { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public bool IsError { get; private set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                IsError = false;
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                _errorMessage = value;
                IsError = true;
            }
        }
    }

    public enum MessageType
    {
        Information = 1,
        Warning = 2,
        Error = 3

    }

    public enum ResponseStatus
    {
        Ok = 0,
        NotFound = 1,
        Duplicate = 2,
        BadRequest = 3,
        Conflict = 4,

        PassErrorToClient = 100 //this will not throw an exception but will return a service response with 'success=false' and the message provided
    }

    public enum DataResponseStatus
    {
        CONFLICT = 1
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        public ResponseViewModel()
        {

        }

        public ResponseViewModel(T data)
        {
            Data = data;
        }

        public ResponseViewModel(T data, bool success)
        {
            Data = data;
            Success = success;
        }

        public T Data { get; set; }
    }

    public class ResponseWithTotalViewModel<T> : ResponseViewModel<T>
    {
        public int Total { get; set; }
    }

    public class ResponseViewModel
    {
        public MessageType MessageType { get; set; }
        public bool IsError { get; private set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }

        private string _errorMessage;

        [JsonIgnore]
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; } = true;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                IsError = false;
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                _errorMessage = value;
                IsError = true;
            }
        }

        public bool HasNextPage { get; set; }

        public ResponseViewModel()
        {

        }
    }
}