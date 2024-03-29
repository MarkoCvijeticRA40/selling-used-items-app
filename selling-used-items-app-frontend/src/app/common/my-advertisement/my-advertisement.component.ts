import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdvertisementService } from '../../service/advertisement.service';
import { Advertisement } from '../../model/advertisement';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-my-advertisement',
  templateUrl: './my-advertisement.component.html',
  styleUrl: './my-advertisement.component.css'
})
export class MyAdvertisementComponent implements OnInit {

  userId : number = 2;

  advertisements: Advertisement[] = [];

  constructor(private router: Router, private advertisementService: AdvertisementService) {}
  
  ngOnInit(): void {
    this.advertisementService.getByUserId(this.userId).subscribe(res => {
      this.advertisements = res;
    })
  }

  confirm(advertisement: Advertisement) {
    advertisement.advertisementStatus = 2;
    advertisement.reservedBy = this.userId;
    this.advertisementService.sell(advertisement.id).subscribe((res) => {
      alert("Succesfully sold advertisement!");
    });
  }

  refuse(advertisement: Advertisement) {
    advertisement.advertisementStatus = 0;
    advertisement.reservedBy = this.userId;
    this.advertisementService.update(advertisement.id, advertisement).subscribe((res) => {
      alert("Succesfully refuse advertisement!");
    });
  }

  navigateToAdvertisements(advertisementId: number): void {
    this.router.navigate(['/home/edit-advertisement', advertisementId]);
  }
  
  shouldShowEditDelete(): boolean {
    return this.advertisements.some(ad => ad.advertisementStatus === 0);
  }

  shouldShowConfirmRefuse(): boolean {
    return this.advertisements.some(ad => ad.advertisementStatus === 1);
  }

  shouldShowActions(): boolean {
    return this.shouldShowEditDelete() || this.shouldShowConfirmRefuse();
  }

  deleteAdvertisement(advertisementId: number) {
    this.advertisementService.delete(advertisementId).pipe(
      catchError((error) => {
        return of([]); 
      })
    ).subscribe(res => {
      alert("Succesfully delete advertisement!");
      this.fetchAdvertisements(); 
    })
  }

  fetchAdvertisements() {
    this.advertisementService.getByUserId(this.userId).subscribe(res => {
      this.advertisements = res;
    })
  }
}