using API_Automation.Dtos.Common;

namespace API_Automation.DataFactory
{
    public class AddNewPet
    {
        public static Pets ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new Pets
            {
                Id = 12345,
                Category = new Category { Id = 1, Name = "Dog" },
                Name = "Buddy",
                PhotoUrls = ["https://media.istockphoto.com/id/1534040386/photo/an-o"], // List of photo URLs
                Tags =
                [
                    new Tag { Id = 1, Name = "Friendly" }
                ],
                Status = PetStatus.available
            };
        }
    }
}
