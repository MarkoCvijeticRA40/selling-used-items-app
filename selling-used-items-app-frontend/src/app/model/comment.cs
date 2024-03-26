export class Comment {
  id: number;
  creatorId: number;
  targetUserId: number;
  advertisementId: number;
  message: string;
  rating: number;
  isApproved: boolean;

  constructor(
    id: number,
    creatorId: number,
    targetUserId: number,
    advertisementId: number,
    message: string,
    rating: number,
    isApproved: boolean
  ) {
    this.id = id;
    this.creatorId = creatorId;
    this.targetUserId = targetUserId;
    this.advertisementId = advertisementId;
    this.message = message;
    this.rating = rating;
    this.isApproved = isApproved;
  }
}
