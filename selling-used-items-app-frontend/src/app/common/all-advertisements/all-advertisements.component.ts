import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementService } from '../../service/advertisement.service';
import { catchError, of } from 'rxjs';
import { Advertisement } from '../../model/advertisement';
import { error } from 'console';


@Component({
  selector: 'app-all-advertisements',
  templateUrl: './all-advertisements.component.html',
  styleUrls: ['./all-advertisements.component.css']
})
export class AllAdvertisementsComponent implements OnInit {
 
  advertisements: any = [];
  name: string = '';
  firstLetter: string = '';
  sortBy: string = '';

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private advertisementService: AdvertisementService) {

  }

  deleteAdvertisement(advertisementId: number) {
    this.advertisementService.delete(advertisementId).pipe(
      catchError((error) => {
        return of([]);
      })
    ).subscribe(res => {
      alert("Succesfully delete advertisement!");
      this.advertisements = this.fetchAdvertisements();
    })
  }
  
  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
        this.name = params['name'] || '';
        this.fetchAdvertisements();
    });
  }

  fetchAdvertisements() {
    if (this.name || this.firstLetter || this.sortBy) {
      this.advertisementService.search(this.name || '', this.firstLetter || '', this.sortBy || '').pipe(
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

  onAlphabetClick(letter: string) {
    if (this.firstLetter === letter) {
        this.firstLetter = '';
    } else {
        this.firstLetter = letter;
    }
    const currentUrlTree = this.router.parseUrl(this.router.url);
    const currentParams = { ...currentUrlTree.queryParams };
    currentParams['first_letter'] = this.firstLetter || null;
    this.router.navigate([], {
        queryParams: currentParams,
        queryParamsHandling: 'merge',
    }).then(() => {
        this.fetchAdvertisements();
    });
  } 

  onSortChange(type: string) {
    console.log(this.sortBy);
    console.log(this.firstLetter);
    this.sortBy = type;
    const currentUrlTree = this.router.parseUrl(this.router.url);
    const currentParams = { ...currentUrlTree.queryParams };
    currentParams['sortBy'] = this.sortBy || null; 
    this.router.navigate([], {
        queryParams: currentParams,
        queryParamsHandling: 'merge',
    }).then(() => {
        this.fetchAdvertisements();
    });
  }
  
  navigateToAdvertisementDisplay(advertisementId: number): void {
    this.router.navigate(['/home/advertisement', advertisementId]);
  }
}
