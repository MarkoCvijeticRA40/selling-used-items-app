import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-advertisements',
  templateUrl: './all-advertisements.component.html',
  styleUrls: ['./all-advertisements.component.css'] // Ispravite styleUrl u styleUrls
})
export class AllAdvertisementsComponent {

  advertisements: any[] = [
    { name: 'Advertisement 1', price: '$100', description: 'Nudim polovan automobil', status: 'Reserved' },
    { name: 'Advertisement 2', price: '$200', description: 'Nudim polovan telefon', status: 'Purchased' },
    { name: 'Advertisement 3', price: '$300', description: 'Nudim polovan televizor', status: 'Available' }
  ];

  constructor(private router: Router) {}

  navigateToAdvertisementDisplay(): void {
    this.router.navigate(['/home/advertisement']);
  }

}