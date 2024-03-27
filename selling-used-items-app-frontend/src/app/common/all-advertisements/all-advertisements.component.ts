import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementService } from '../../service/advertisement.service';
import { catchError, of } from 'rxjs';


@Component({
  selector: 'app-all-advertisements',
  templateUrl: './all-advertisements.component.html',
  styleUrls: ['./all-advertisements.component.css']
})
export class AllAdvertisementsComponent implements OnInit {
 
  advertisements: any = [];
  name: string = '';

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private advertisementService: AdvertisementService) {
    
  }
  
  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
        this.name = params['name'];
        this.fetchAdvertisements();
    });
  }

  fetchAdvertisements() {
    if (this.name) {
      this.advertisementService.search(this.name).pipe(
        catchError((error) => {
          console.error('Error fetching advertisements:', error);
          return of([]);
        })
      ).subscribe(res => {
        this.advertisements = res;
      });
    } else {
      this.advertisementService.getAll().pipe(
        catchError((error) => {
          console.error('Error fetching advertisements:', error);
          return of([]);
        })
      ).subscribe(res => {
        this.advertisements = res;
      });
    }
  }

  navigateToAdvertisementDisplay(): void {
    this.router.navigate(['/home/advertisement']);
  }
}
