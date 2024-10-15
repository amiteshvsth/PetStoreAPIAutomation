using API_Automation.Dtos;
using API_Automation.Dtos.Common;
using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class UpdateExistingPet
    {
        public static Pets ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new Pets
            {
                Id = 12345, // Assign a pet ID
                Category = new Category { Id = 1, Name = "Dog" }, // Assign a Category object
                Name = "Buddy", // Required field for the pet's name
                PhotoUrls = ["https://example.com/photo1.jpg", "https://example.com/photo2.jpg"], // List of photo URLs
                Tags =
                [
                    new Tag { Id = 1, Name = "Friendly" },
                    new Tag { Id = 2, Name = "Energetic" }
                ],
                Status = PetStatus.available // Assign a pet status (Enum)
            };
        }
    }
}
