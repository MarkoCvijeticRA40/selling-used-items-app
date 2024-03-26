export class User {
    id: number = 0;
    name: string = '';
    lastName: string = '';
    username: string = '';
    password: string = '';
    email: string = '';
    userRole: number = 0;
    isBlocked: boolean = false;
  
    constructor(
      id: number = 0,
      name: string = '',
      lastName: string = '',
      username: string = '',
      password: string = '',
      email: string = '',
      userRole: number = 0
    ) {
      this.id = id;
      this.name = name;
      this.lastName = lastName;
      this.username = username;
      this.password = password;
      this.email = email;
      this.userRole = userRole;
    }
  }
  