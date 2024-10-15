using System.Text.Json.Serialization;

namespace API_Automation.Dtos.Common
{
    public class Category
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }

}