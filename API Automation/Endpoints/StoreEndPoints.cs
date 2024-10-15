namespace API_Automation.Endpoints
{
    public class StoreEndPoints
    {
        public static string GetPetInventoryByStatus() => "store/inventory";
        public static string PlaceOrderPet() => "store/order";
        public static string FindPurchaseOrderById(long orderId) => $"store/order/{orderId}";
        public static string DeletePurchaseOrderById(long orderId) => $"store/order/{orderId}";
    }
}
