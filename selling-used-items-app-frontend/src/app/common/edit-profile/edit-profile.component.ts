import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../model/user';
import { UserService } from '../../service/user.service';
import { catchError, of } from 'rxjs';
import { error } from 'console';
import { AuthorizationService } from '../../service/authorization.service';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrl: './edit-profile.component.css'
})
export class EditProfileComponent implements OnInit {

  user : User = new User();

  userId : number = 0;
  
  constructor(private router: Router, private userService: UserService, private authorizationService: AuthorizationService) { }

  editProfile() {
    if (this.user.name && this.user.lastName && this.user.username) {
      this.userService.update(this.user).pipe(
        catchError((error) => {
          console.error('Error with updating user,', error);
          return of(null);
        })
      ).subscribe(res => {
          alert("Succesfully update user!");
      });
    } else {
      alert("Please fill in all fields.");
    }
  }
  
  ngOnInit(): void {
    const userId = this.authorizationService.getUserID();
  if (userId !== null) {
  this.userId = userId;
  this.userService.get(this.userId).pipe(
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

  redirectToChangePassword(): void {
    this.router.navigate(['/home/profile/change-password']);
  }
}
