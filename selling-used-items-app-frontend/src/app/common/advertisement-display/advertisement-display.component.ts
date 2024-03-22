import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-advertisement-display',
  templateUrl: './advertisement-display.component.html',
  styleUrls: ['./advertisement-display.component.css'] // Ispravite styleUrl u styleUrls
})
export class AdvertisementDisplayComponent {

  advertisement: any = {
    name: 'Advertisement 1',
    price: '$100',
    commentaries: 'This is a great product! Rating: 4.5, Dejan Dejanovic',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut euismod, justo non rhoncus tincidunt, risus felis consectetur dolor.',
    status: 'Available'
  };

  constructor(private router: Router) {}

  navigateToAdvertisements(): void {
    this.router.navigate(['/home/advertisements']);
  }

  purchaseAdvertisement(): void {
    alert('Successfully purchased advertisement!');
    this.navigateToAdvertisements();
  }
}
