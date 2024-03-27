export class Purchase {
    id: number = 0;
    userId: number = 0;
    advertisementId: number = 0;
  
    constructor(
      id: number = 0,
      userId: number = 0,
      advertisementId: number = 0
    ) {
      this.id = id;
      this.userId = userId;
      this.advertisementId = advertisementId;
    }
  }
  