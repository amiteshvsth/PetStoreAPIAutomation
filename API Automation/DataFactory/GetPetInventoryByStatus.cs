using API_Automation.Dtos.Common;

namespace API_Automation.DataFactory
{
    public class GetPetInventoryByStatus
    {
        public static Inventory ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new Inventory
            {
                AdditionalProp1 = 1,
                AdditionalProp2 = 2,
                AdditionalProp3 = 3,
            };
        }
    }
}
