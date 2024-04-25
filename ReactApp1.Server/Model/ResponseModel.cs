namespace ReactApp1.Server.Model
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public bool IsActive { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
