namespace Api.SeedWork
{
    public class Response
    {
        public Response(string message, bool success = true, object data = null)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string Message { get; private set; }
        public bool Success { get; private set; }
        public object Data { get; private set; }
    }
}