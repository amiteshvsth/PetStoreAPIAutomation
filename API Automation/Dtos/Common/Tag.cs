using System.Text.Json.Serialization;

namespace API_Automation.Dtos.Common
{
    public class Tag
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }

}