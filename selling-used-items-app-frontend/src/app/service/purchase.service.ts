import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Purchase } from '../model/purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  private baseUrl = 'http://localhost:5152/api/purchases';

  constructor(private http: HttpClient) { }

  getAllPurchases(): Observable<Purchase[]> {
    return this.http.get<Purchase[]>(this.baseUrl);
  }

  getPurchaseById(purchaseId: number): Observable<Purchase> {
    const url = `${this.baseUrl}/${purchaseId}`;
    return this.http.get<Purchase>(url);
  }

  createPurchase(purchase: Purchase): Observable<Purchase> {
    return this.http.post<Purchase>(this.baseUrl, purchase);
  }

  updatePurchase(purchase: Purchase): Observable<Purchase> {
    const url = `${this.baseUrl}/${purchase.id}`;
    return this.http.put<Purchase>(url, purchase);
  }

  deletePurchase(purchaseId: number): Observable<void> {
    const url = `${this.baseUrl}/${purchaseId}`;
    return this.http.delete<void>(url);
  }
}