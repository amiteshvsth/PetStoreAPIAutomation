using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Automation.Dtos.Common
{
    public class Pets
    {
        
        public long Id { get; set; }
        
        public required Category Category { get; set; }

        public required string Name { get; set; }

        public required List<string> PhotoUrls { get; set; }

        public required List<Tag> Tags { get; set; }

        public PetStatus Status { get; set; }
    }
}