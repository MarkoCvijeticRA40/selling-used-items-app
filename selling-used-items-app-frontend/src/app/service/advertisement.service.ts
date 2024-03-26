import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Advertisement } from '../model/advertisement';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  private baseUrl = 'http://localhost:5152/api/advertisements';

  constructor(private http: HttpClient) { }

  getAllAdvertisements(): Observable<Advertisement[]> {
    return this.http.get<Advertisement[]>(this.baseUrl);
  }

  getAdvertisementById(advertisementId: number): Observable<Advertisement> {
    const url = `${this.baseUrl}/${advertisementId}`;
    return this.http.get<Advertisement>(url);
  }

  createAdvertisement(advertisement: Advertisement): Observable<Advertisement> {
    return this.http.post<Advertisement>(this.baseUrl, advertisement);
  }

  updateAdvertisement(advertisementId: number, advertisement: Advertisement): Observable<void> {
    const url = `${this.baseUrl}/${advertisementId}`;
    return this.http.put<void>(url, advertisement);
  }

  deleteAdvertisement(advertisementId: number): Observable<void> {
    const url = `${this.baseUrl}/${advertisementId}`;
    return this.http.delete<void>(url);
  }

  searchAdvertisements(params: any): Observable<Advertisement[]> {
    const url = `${this.baseUrl}/search`;
    return this.http.get<Advertisement[]>(url, { params });
  }

  sellAdvertisement(advertisementId: number): Observable<void> {
    const url = `${this.baseUrl}/${advertisementId}/sell`;
    return this.http.put<void>(url, null);
  }
}