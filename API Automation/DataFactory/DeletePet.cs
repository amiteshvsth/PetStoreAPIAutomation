using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class DeletePet
    {
        public static DeletePetRequest ValidData()
        {
            return new DeletePetRequest
            {
                PetId = 12345,
            };
        }
    }
}
