using API_Automation.Dtos.Common;

namespace API_Automation.Dtos.Pet
{
    public class FindPetsByStatusRequest
    {
        public required List<PetStatus> Status { get; set; }
    }
}
