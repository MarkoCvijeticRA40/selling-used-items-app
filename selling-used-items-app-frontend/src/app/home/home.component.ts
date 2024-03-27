import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, UrlTree } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  name: string = "";
  advertisements: any[] = [];
  
  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(params => {
      if (params['name']) {
        this.name = params['name'];
      }
    });
  }

  onSearchChange() {
    const url = this.name ? `/home/advertisements?name=${this.name}` : '/home/advertisements';
    this.router.navigateByUrl(url);
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
    alert("asdasd");
    this.router.navigate(['/home/add-comment']);
  }

  navigateToComments() {
    this.router.navigate(['/home/comments']);
  }
}