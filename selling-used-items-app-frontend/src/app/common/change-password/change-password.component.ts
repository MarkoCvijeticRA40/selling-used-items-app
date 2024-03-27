import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, of } from 'rxjs';
import { User } from '../../model/user';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent implements OnInit{

  user : User = new User();
  newPassword: string = '';
  confirmNewPassword: string = '';
  
  constructor(private router: Router, private userService: UserService) { }

  editProfile() {
    console.log(this.user);
    if(this.newPassword && this.confirmNewPassword) {
      if(this.newPassword === this.confirmNewPassword) {
        console.log(this.user);
        this.user.password = this.newPassword;
        this.userService.changePassword(this.user).pipe(
          catchError((error) => {
            console.error('Error with updating user,', error);
            return of(null);
          })
        ).subscribe(res => {
            alert("Succesfully update user!");
        });
      } 
      else {
        alert("Password not match!");
      }
    } else {
      alert("Please fill in all fields.");
    }
  }
  
  ngOnInit(): void {
    this.userService.get(2).pipe(
      catchError((error) => {
        console.error('Error fetching user', error);
        return of(null); 
      })
    ).subscribe(res => {
      if (res) { 
        this.user = res; 
      }
    });
  }
}
