import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor() { }

  getToken(): string | null {
    return localStorage.getItem('jwt');
  }

  isTokenExpired(token: string): boolean {
    if (!token) return true;
    const decodedToken = this.decodeJWT(token);
    const currentTime = Math.floor(Date.now() / 1000);
    return decodedToken.exp < currentTime;
  }

  private decodeJWT(token: string): any {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    return JSON.parse(atob(base64));
  }

  checkUserRole(token: string, requiredRole: string): boolean {
    if (!token) return false;
    const decodedToken = this.decodeJWT(token);
    return decodedToken.role === requiredRole;
  }

  authorize(requiredRole: string): boolean {
    const token = this.getToken();
    if (!token || this.isTokenExpired(token) || !this.checkUserRole(token, requiredRole)) {
      return false;
    }
    return true;
  }
}
