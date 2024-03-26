export class Report {
  id: number;
  userId: number;
  reason: string;

  constructor(id: number, userId: number, reason: string) {
    this.id = id;
    this.userId = userId;
    this.reason = reason;
  }
}
