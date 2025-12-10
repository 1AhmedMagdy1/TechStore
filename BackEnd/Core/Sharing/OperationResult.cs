namespace Core.Sharing
{
    public class OperationResult
    {
        public bool Success { get;protected set; }
        public string? Message { get; protected set; }
        public List<string>? Errors { get; set; }
        public int? StatusCode { get; set; }
        public OperationResult()
        {
            
        }
        public static OperationResult Fail(string message,IEnumerable<string>?errors,int? statuscode)
            => new OperationResult
            {
                Success = false,
                Message = message,
                Errors = errors?.ToList(),
                StatusCode = statuscode
            };

        public static OperationResult OK(string message,int statuscode)
            => new OperationResult
            {
                Success = true,
                Message = message,
                StatusCode = statuscode
            };
    }
    public class OperationResult<T>:OperationResult
    {
        public T? Data { get; set; }
        public OperationResult()
        {

        }
        public static OperationResult<T> Fail(string message, IEnumerable<string>? errors, int? statuscode)
            => new OperationResult<T>
            {
                Success = false,
                Message = message,
                Errors = errors?.ToList(),
                StatusCode = statuscode
            };
        public static OperationResult<T> OK(T data, string message, int statuscode)
            => new OperationResult<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statuscode
            };
    }


}
