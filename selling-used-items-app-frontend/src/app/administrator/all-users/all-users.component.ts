import { Component } from '@angular/core';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrl: './all-users.component.css'
})
export class AllUsersComponent {
  users: any[] = [
    { name: 'John', lastname: 'Doe', username: 'john_doe', email: 'john@example.com', userRole: 'Admin', status: 'Active' },
    { name: 'Jane', lastname: 'Smith', username: 'jane_smith', email: 'jane@example.com', userRole: 'User', status: 'Blocked' },
    { name: 'Alice', lastname: 'Johnson', username: 'alice_johnson', email: 'alice@example.com', userRole: 'User', status: 'Active' }
  ];

  blockUser(user: any): void {
    user.status = 'Blocked';
  }

  unblockUser(user: any): void {
    user.status = 'Active';
  }
}