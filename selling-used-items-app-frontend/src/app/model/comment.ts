export class Comment {
    id: number = 0;
    creatorId: number = 0;
    purchaseId: number = 0;
    targetUserId: number = 0;
    message: string = '';
    rating: number = 0;
    isApproved: boolean = false;
  
    constructor(
      id: number = 0,
      creatorId: number = 0,
      targetUserId: number = 0,
      advertisementId: number = 0,
      message: string = '',
      rating: number = 0,
      isApproved: boolean = false
    ) {
      this.id = id;
      this.creatorId = creatorId;
      this.targetUserId = targetUserId;
      this.message = message;
      this.rating = rating;
      this.isApproved = isApproved;
    }
  }
  