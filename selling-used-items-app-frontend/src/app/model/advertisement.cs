export class Advertisement {
  id: number;
  price: number;
  name: string;
  description: string;
  dateCreated: Date;
  location: string;
  userId: number;
  advertisementStatus: number;

  constructor(
    id: number,
    price: number,
    name: string,
    description: string,
    dateCreated: Date,
    location: string,
    userId: number,
    advertisementStatus: number
  ) {
    this.id = id;
    this.price = price;
    this.name = name;
    this.description = description;
    this.dateCreated = dateCreated;
    this.location = location;
    this.userId = userId;
    this.advertisementStatus = advertisementStatus;
  }
}
