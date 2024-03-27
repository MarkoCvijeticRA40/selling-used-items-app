import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { User } from '../model/user';
import { catchError, of } from 'rxjs';
import { error } from 'console';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  user : User = new User();

  ngOnInit() {
  }

  constructor(private router: Router, private userService: UserService) { }

  register() {
    if (!this.user.name || !this.user.lastName || !this.user.username || !this.user.email || !this.user.password) {
      alert("Please fill in all fields.");
      return;
    }
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(this.user.email)) {
      alert("Please enter a valid email address.");
      return;
    }
    this.userService.create(this.user).pipe(
      catchError((error) => {
        console.error("Error registering user", error);
        return of(null);
      })
    ).subscribe(res => {
      if(res) {
        alert("User registered successfully!");
        this.router.navigate(['/login']);
      } else {
        console.error("User registration failed.");
      }
    });
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
