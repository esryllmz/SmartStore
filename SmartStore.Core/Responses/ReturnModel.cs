namespace SmartStore.Core.Responses
{
    public class ReturnModel<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }
    }
}
