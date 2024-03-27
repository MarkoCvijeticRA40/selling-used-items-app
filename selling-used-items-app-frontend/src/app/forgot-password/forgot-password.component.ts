import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { catchError, of } from 'rxjs';
import { error } from 'console';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent {

  email : string = '';

  ngOnInit() {
  
  }

  constructor(private router: Router, private userService: UserService) { }

  forgotPassword() {
    if (!this.email) {
      alert('Please enter your email address.');
      return;
    }
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (!emailPattern.test(this.email)) {
      alert('Please enter a valid email address.');
      return;
    }
    this.userService.forgotPassword(this.email).pipe(
      catchError((error) => {
        console.error('Error sending forgot password request:', error);
        return of([]);
      })
    ).subscribe(() => {
      alert('Successfully sent to your email address.');
    });
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

}
