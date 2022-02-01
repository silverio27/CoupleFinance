namespace Identity.SeedWork
{
    public class Response : Response<object>
    {

    }
    public  class Response<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        private Response(bool success)
        {
            Success = success;
        }
        protected Response() { }
        public static Response<T> Fail()
        {
            return new Response<T>(false);
        }
        public static Response<T> Ok()
        {
            return new Response<T>(true);
        }
        public Response<T> WithMessage(string message)
        {
            Message = message;
            return this;
        }
        public Response<T> WithData(T data)
        {
            Data = data;
            return this;
        }
    }
}