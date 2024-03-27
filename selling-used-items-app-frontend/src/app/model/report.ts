export class Report {
    id: number = 0;
    userId: number = 0;
    reason: string = '';
  
    constructor(
      id: number = 0,
      userId: number = 0,
      reason: string = ''
    ) {
      this.id = id;
      this.userId = userId;
      this.reason = reason;
    }
  }
  