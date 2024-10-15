using API_Automation.Dtos.Common;

namespace API_Automation.Dtos.Pet
{
    public class UpdateExistingPetWithFormDataRequest
    {
        public long PetId { get; set; }
        public required string Name { get; set; } // Required field
        public PetStatus Status { get; set; } // Enum for pet status in the store
    }
}
