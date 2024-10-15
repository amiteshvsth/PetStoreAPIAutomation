namespace API_Automation.Dtos.Common
{
    public class APIResponse
    {
        public int Code { get; set; }
        public required string Type { get; set; }
        public required string Message { get; set; }
    }

}