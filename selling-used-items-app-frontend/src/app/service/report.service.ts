import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private baseUrl = 'http://localhost:5152/api/reports'; // URL tvog backend-a

  constructor(private http: HttpClient) { }

  getAllReports(): Observable<Report[]> {
    return this.http.get<Report[]>(this.baseUrl);
  }

  createReport(report: Report): Observable<Report> {
    return this.http.post<Report>(this.baseUrl, report);
  }
}