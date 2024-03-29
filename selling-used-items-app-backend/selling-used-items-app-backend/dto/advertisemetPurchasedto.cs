namespace selling_used_items_app_backend.dto
{
    public class AdvertisementPurchaseDTO
    {
        public int purchaseId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int advertisementStatus { get; set; }
        public int advertisementCreatorId { get; set; }
    }
}