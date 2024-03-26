import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  constructor(private router: Router) { }

  ngOnInit() {

  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToHome() {
    this.router.navigate(['/home/advertisements']);
  }

  navigateToProfile() {
    this.router.navigate(['/home/profile/edit-profile']);
  }

  navigateToCreateAdvertisement() {
    this.router.navigate(['/home/create-advertisement']);
  }

  navigateToReportUser() {
    this.router.navigate(['/home/report-user']);
  }

  navigateToRateUser() {
    this.router.navigate(['/home/rate-user']);
  }
}