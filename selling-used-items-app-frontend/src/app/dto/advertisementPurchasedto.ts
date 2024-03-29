export class AdvertisementPurchaseDTO {
    
    purchaseId: number = 0;
    name: string = '';
    price: number = 0;
    description: string = '';
    advertisementStatus: number = 0;
    advertisementCreatorId: number = 0;

    public constructor(obj?: any) {
        if(obj) {
            this.purchaseId = obj.purchaseId;
            this.name = obj.name;
            this.price = obj.price;
            this.description = obj.description;
            this.advertisementStatus = obj.advertisementStatus;
            this.advertisementCreatorId = obj.advertisementCreatorId;
        }
    }
  }