import { Component } from '@angular/core';

@Component({
  selector: 'app-my-advertisement',
  templateUrl: './my-advertisement.component.html',
  styleUrl: './my-advertisement.component.css'
})
export class MyAdvertisementComponent {

  advertisements: any[] = [
    { name: 'Advertisement 1', price: '$100', description: 'Nudim polovan automobil', status: 'Reserved' },
    { name: 'Advertisement 2', price: '$200', description: 'Nudim polovan telefon', status: 'Purchased' },
    { name: 'Advertisement 3', price: '$300', description: 'Nudim polovan televizor', status: 'Available' }
  ];

}
