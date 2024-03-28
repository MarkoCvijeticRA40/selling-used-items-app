import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Advertisement } from '../model/advertisement';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  route: string = 'http://localhost:5152/api/advertisements';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getAll(): Observable<Advertisement[]> {
    return this.http.get<Advertisement[]>(this.route, { headers: this.headers });
  }

  get(advertisementId: number): Observable<Advertisement> {
    return this.http.get<Advertisement>(`${this.route}/${advertisementId}`, { headers: this.headers });
  }

  create(advertisement: Advertisement): Observable<Advertisement> {
    return this.http.post<Advertisement>(this.route, advertisement, { headers: this.headers });
  }

  update(advertisementId: number, advertisement: Advertisement): Observable<void> {
    return this.http.put<void>(`${this.route}/${advertisementId}`, advertisement, { headers: this.headers });
  }

  delete(advertisementId: number): Observable<void> {
    return this.http.delete<void>(`${this.route}/${advertisementId}`, { headers: this.headers });
  }

  search(name: string, firstLetter: string, sortBy: string): Observable<any> {
    return this.http.get<any>(`${this.route}/search?name=${name}&firstLetter=${firstLetter}&sortBy=${sortBy}`, { headers: this.headers });
  }

  sell(advertisementId: number): Observable<void> {
    return this.http.put<void>(`${this.route}/${advertisementId}/sell`, null, { headers: this.headers });
  }

  getByUserId(userId: number): Observable<Advertisement[]> {
    return this.http.get<Advertisement[]>(`${this.route}/user/${userId}`, { headers: this.headers });
  }
}
