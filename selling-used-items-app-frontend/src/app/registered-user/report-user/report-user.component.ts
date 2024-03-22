import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-report-user',
  templateUrl: './report-user.component.html',
  styleUrl: './report-user.component.css'
})
export class ReportUserComponent {

  constructor(private router: Router) { }

  submitReport() {
    alert("Successfully send report!")
    this.router.navigate(['/home/advertisements']); 
  }

  goBack() {
    this.router.navigate(['/home/advertisements']); 
  }

}
