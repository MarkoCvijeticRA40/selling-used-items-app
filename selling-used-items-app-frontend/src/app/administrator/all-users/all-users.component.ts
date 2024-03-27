import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user.service';
import { catchError, of } from 'rxjs';
import { error } from 'console';
import { User } from '../../model/user';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrl: './all-users.component.css'
})
export class AllUsersComponent implements OnInit {

  users: User[] = [];

  constructor(private userService: UserService) {

  }
  
  ngOnInit(): void {
   this.fetchUser();
  }

  fetchUser() {
    this.userService.getAll().pipe(
      catchError((error) => {
        console.error("Error fetching users", error);
        return of([]);
      })
    ).subscribe(res => {
      this.users = res;
    })
  }

  blockUser(user: any): void {
    this.userService.block(user.id).pipe(
      catchError((error) => {
        console.error("Error durgin block user", error);
        return of([]);
      })
    ).subscribe(res => {
      alert("Succesfully block user!");
      this.fetchUser();
    })
  }

  unblockUser(user: any): void {
    this.userService.unblock(user.id).pipe(
      catchError((error) => {
        console.error("Error durgin block user", error);
        return of([]);
      })
    ).subscribe(res => {
      alert("Succesfully unblock user!");
      this.fetchUser();
    })
  }
}