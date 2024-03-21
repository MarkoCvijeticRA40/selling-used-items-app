import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  childComponent: string = '';

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    console.log(this.childComponent);
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}