using API_Automation.Dtos.Common;

namespace API_Automation.DataFactory
{
    public class PlaceOrderPet
    {
        public static Order ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new Order
            {
                Id = 1,
                PetId = 1,
                Quantity = 1,
                ShipDate = DateTime.Parse("2024-10-07T10:39:12.084Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Status = OrderStatus.placed,
                Complete = true
            };
        }
    }
}
