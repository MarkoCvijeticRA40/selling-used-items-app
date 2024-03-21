import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-header-bar',
  templateUrl: './header-bar.component.html',
  styleUrls: ['./header-bar.component.css']
})
export class HeaderBarComponent implements OnInit {
  
  showProfile: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.checkProfileInUrl();
  }

  checkProfileInUrl() {
    this.showProfile = this.router.url.includes('profile');
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
