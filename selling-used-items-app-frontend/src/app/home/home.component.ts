import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, UrlTree } from '@angular/router';
import { log } from 'console';

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
    let queryParams: any = {};
    if (this.name) {
      queryParams['name'] = this.name;
    }
    const currentUrlTree = this.router.parseUrl(this.router.url);
    const currentParams = { ...currentUrlTree.queryParams, ...queryParams };
    if (!this.name) {
      delete currentParams['name'];
    }
    const queryString = Object.keys(currentParams).map(key => `${key}=${currentParams[key]}`).join('&');
    const url = '/home/advertisements' + (queryString ? `?${queryString}` : '');
    this.router.navigateByUrl(url);
  }

  logout(): void {
    localStorage.removeItem('jwt');
    this.router.navigate(['/login']);
  }
  
  navigateToLogin() {
    this.logout();
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
    this.router.navigate(['/home/add-comment']);
  }

  navigateToComments() {
    this.router.navigate(['/home/comments']);
  }
}