export class Purchase {
  id: number;
  userId: number;
  advertisementId: number;

  constructor(id: number, userId: number, advertisementId: number) {
    this.id = id;
    this.userId = userId;
    this.advertisementId = advertisementId;
  }
}
