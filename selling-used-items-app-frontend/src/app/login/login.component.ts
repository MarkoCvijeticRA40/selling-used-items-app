import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { User } from '../model/user';
import { catchError, of } from 'rxjs';
import { error } from 'console';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{

  email : String = '';
  password : String = '';

  ngOnInit() {
  }

  constructor(private router: Router, private userService: UserService) { }

  login() {
    this.userService.login(this.email.toString(), this.password.toString()).pipe(
      catchError((error) => {
        return of([]);
      })
    ).subscribe(res => {
      if (res && res.token) {
        localStorage.setItem("jwt", res.token); 
        console.log("ovde");
        this.router.navigate(['/home/advertisements']); 
      } else {
        alert("Wrong credentials!");
      }
    });
  }
}