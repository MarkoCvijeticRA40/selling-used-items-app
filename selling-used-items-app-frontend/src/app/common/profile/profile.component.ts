import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizationService } from '../../service/authorization.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

  constructor(private router: Router, private authorizationService : AuthorizationService) { }

  ngOnInit(): void {
    this.canViewAllUsers();
  }

  canViewAllUsers(): boolean {
    const token = this.authorizationService.getToken();
    if (!token) return false;
    const payload = this.authorizationService.decodeJWT(token);
    console.log(payload);
    if (payload.UserRole === 'RegisteredUser') return false; 
    return true;
}
}
