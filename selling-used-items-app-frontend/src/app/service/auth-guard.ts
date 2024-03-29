import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot , Router } from '@angular/router';
import { AuthorizationService } from './authorization.service';
import { CanActivate } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private authService: AuthorizationService, private router: Router) {}
    
    canActivate(route: ActivatedRouteSnapshot): boolean {
        const expectedRole = route.data['expectedRole'];
        if (!this.authService.authorize(expectedRole)) {
          this.router.navigate(['/unauthorize']);
          return false;
        }
        return true;
      }
      
}
