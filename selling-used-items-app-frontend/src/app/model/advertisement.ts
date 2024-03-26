export class Advertisement {
    id: number = 0;
    price: number = 0;
    name: string = '';
    description: string = '';
    dateCreated: Date = new Date();
    location: string = '';
    userId: number = 0;
    advertisementStatus: number = 0;

    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.price = obj.price;
            this.name = obj.name;
            this.description = obj.description;
            this.dateCreated = obj.dateCreated;
            this.location = obj.location;
            this.userId = obj.userId;
            this.advertisementStatus = obj.advertisementStatus;
        }
    }
}
