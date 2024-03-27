import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>('http://localhost:5152/api/users', { headers: this.headers });
  }

  get(userId: number): Observable<User> {
    return this.http.get<User>('http://localhost:5152/api/users/' + userId, { headers: this.headers });
  }

  create(user: User): Observable<User> {
    return this.http.post<User>('http://localhost:5152/api/users/register', user, { headers: this.headers });
  }

  update(user: User): Observable<User> {
    return this.http.put<User>('http://localhost:5152/api/users/' + user.id, user, { headers: this.headers });
  }

  delete(userId: number): Observable<void> {
    return this.http.delete<void>('http://localhost:5152/api/users/' + userId, { headers: this.headers });
  }

  block(userId: number): Observable<void> {
    return this.http.put<void>('http://localhost:5152/api/users/block/' + userId, null, { headers: this.headers });
  }

  unblock(userId: number): Observable<void> {
    return this.http.put<void>('http://localhost:5152/api/users/unblock/' + userId, null, { headers: this.headers });
  }
 
  forgotPassword(email: string): Observable<void> {
    
    return this.http.patch<void>(`http://localhost:5152/api/users/forgot-password?email=${email}`, { headers: this.headers });
  }  
}
