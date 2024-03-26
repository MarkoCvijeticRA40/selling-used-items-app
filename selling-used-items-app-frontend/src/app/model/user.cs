export class User {
  
  id: number;
  name: string;
  lastName: string;
  username: string;
  password: string;
  email: string;
  userRole: number;
  isBlocked: boolean = false;

  constructor(id: number, name: string, lastName: string, username: string, password: string, email: string, userRole: number) {
    this.id = id;
    this.name = name;
    this.lastName = lastName;
    this.username = username;
    this.password = password;
    this.email = email;
    this.userRole = userRole;
  }
}
