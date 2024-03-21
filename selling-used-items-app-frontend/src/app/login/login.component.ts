import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  

  ngOnInit() {
  }

  constructor(private router: Router) { }

  navigateToProfile() {
    this.router.navigate(['/home/profile']);
    console.log("here");
  }
}
