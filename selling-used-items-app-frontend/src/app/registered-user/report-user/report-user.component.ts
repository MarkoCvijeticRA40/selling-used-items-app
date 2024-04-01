import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReportService } from '../../service/report.service';
import { catchError, of } from 'rxjs';
import { Report } from '../../model/report';
import { UserService } from '../../service/user.service';
import { User } from '../../model/user';
import { AuthorizationService } from '../../service/authorization.service';

@Component({
  selector: 'app-report-user',
  templateUrl: './report-user.component.html',
  styleUrl: './report-user.component.css'
})
export class ReportUserComponent implements OnInit {

  report: Report = new Report();
  userId: number = 0;
  user : any;

  constructor(private router: Router, private reportService: ReportService, private userService : UserService, private authorizationService : AuthorizationService) { }
  
  ngOnInit(): void {
    const userId = this.authorizationService.getUserID();
    if (userId !== null) {
      this.userId = userId;
    }  
    this.userService.get(this.userId).pipe(
      catchError((error) => {
        console.error("Problem with getting user!");
        return of(null);
      })
    ).subscribe({
      next: (res) => {
        this.user = res;
      },
      error: (error) => {
        console.error("Error occurred while fetching user:", error);
      }
    });
    console.log(this.user);
  }

  submitReport() {
    this.report.userId = this.userId;
    this.report.reason = (this.report.reason ? this.report.reason + '<br>' : '') + 'Reply to ' + this.user.email;
    this.reportService.createReport(this.report).pipe(
      catchError((error) => {
        console.error("Error during creating report!");
        return of(null);
      })
    ).subscribe(res => {
  })
    
  alert("Successfully send report!")
    this.router.navigate(['/home/advertisements']); 
  }

  goBack() {
    this.router.navigate(['/home/advertisements']); 
  }
}