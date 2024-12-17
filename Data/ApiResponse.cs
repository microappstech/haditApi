namespace haditApi.Data
{
    public class ApiResponse
    {
        public bool Success {  get; set; }
        public string Message { get; set; }
        public ApiResponse(bool Success, string Message = "")
        {
            this.Success = Success;
            this.Message = Message;
        }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public ApiResponse(bool Success, string Message = null , T Data = default(T)) : base(Success, Message) 
        {
            this.Data = Data;
        }
    }
}
