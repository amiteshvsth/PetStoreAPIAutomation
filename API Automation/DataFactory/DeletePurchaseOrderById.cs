using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class DeletePurchaseOrderById
    {
        public static FindPurchaseOrderByIdRequest ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new FindPurchaseOrderByIdRequest
            {
                Id = 1,
            };
        }
    }
}
