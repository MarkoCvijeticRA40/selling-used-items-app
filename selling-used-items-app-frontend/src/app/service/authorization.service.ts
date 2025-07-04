import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

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

  decodeJWT(token: string): any {
    const payload: any = jwtDecode(token);
    return payload;
  }

  checkUserRole(token: string, requiredRole: string): boolean {
    if (!token) return false;
    const payload = this.decodeJWT(token);
    console.log(payload);
    return requiredRole.includes(payload.UserRole);
  }

  authorize(requiredRole: string): boolean {
    const token = this.getToken();
    if (!token || !this.checkUserRole(token, requiredRole) || this.isTokenExpired(token)) {
      return false;
    }
    return true;
  }

  getUserID(): number | null {
    const token = this.getToken();
    if (!token) return null;
    const payload = this.decodeJWT(token);
    const userIDString: string = payload.UserId;
    const userID: number = parseInt(userIDString, 10);
    return userID;
  }
}
