namespace Api.Helper
{
    public class ApiResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public ApiResponse(int statusCode, bool success, string message, T data)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message??GetMessageFromStatusCode(StatusCode);
            Data = data;
        }
        private string GetMessageFromStatusCode(int statuscode)
        {
            return (statuscode) switch
            {
                200 => "Done",
                400 => "one or more validation Error",
                401 => "UnAuthorized",
                500 => "Internal server error",
                _ => null
            };

        }
      
    }
}
