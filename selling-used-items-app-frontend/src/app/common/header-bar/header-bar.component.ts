import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-header-bar',
  templateUrl: './header-bar.component.html',
  styleUrls: ['./header-bar.component.css']
})
export class HeaderBarComponent implements OnInit {
  
  childComponent: string = '';

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.setChildComponent();
    console.log(this.childComponent);
  }

  setChildComponent() {
    const url = this.router.url;
    if (url.includes('profile')) {
      this.childComponent = 'ProfileComponent';
    } else if (url.includes('advertisement')) {
      this.childComponent = 'AdvertisementDisplayComponent';
    } else if (url.includes('change-password')) {
      this.childComponent = 'ChangePasswordComponent';
    } else {
      this.childComponent = '';
    }
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
