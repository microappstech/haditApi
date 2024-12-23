using System.ComponentModel.DataAnnotations;

namespace haditApi.Data
{
    public class ApiPost<T>
    {
        [Required] public string Key { get; set; }
        public T Data { get; set; }
    }
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
        public int Count { get; set; }
        public ApiResponse(bool Success, string Message = null , T Data = default(T), int Count = 0 ) : base(Success, Message)
        {
            this.Data = Data;
            this.Count = Count;
        }

    }
}
