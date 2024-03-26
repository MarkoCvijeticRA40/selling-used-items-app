import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-advertisement',
  templateUrl: './my-advertisement.component.html',
  styleUrl: './my-advertisement.component.css'
})
export class MyAdvertisementComponent {

  constructor(private router: Router) {}

  advertisements: any[] = [
    { name: 'Advertisement 1', price: '$100', description: 'Nudim polovan automobil', status: 'Reserved' },
    { name: 'Advertisement 2', price: '$200', description: 'Nudim polovan telefon', status: 'Purchased' },
    { name: 'Advertisement 3', price: '$300', description: 'Nudim polovan televizor', status: 'Available' }
  ];

  navigateToAdvertisements(): void {
    this.router.navigate(['/home/edit-advertisement']);
  }

  shouldShowEditDelete(): boolean {
    return this.advertisements.some(ad => ad.status === 'Available');
  }

  shouldShowConfirmRefuse(): boolean {
    return this.advertisements.some(ad => ad.status === 'Reserved');
  }

  shouldShowActions(): boolean {
    return this.shouldShowEditDelete() || this.shouldShowConfirmRefuse();
  }

}