import { Component } from '@angular/core';

@Component({
  selector: 'app-my-purchase',
  templateUrl: './my-purchase.component.html',
  styleUrl: './my-purchase.component.css'
})
export class MyPurchaseComponent {
  
  purchases: any[] = [
    { purchaseId: 1 },
    { purchaseId: 2 },
    { purchaseId: 3 },
  ];

  advertisements: any[] = [
    { name: 'Advertisement 1', price: '$100', description: 'Nudim polovan automobil', status: 'Reserved' },
    { name: 'Advertisement 2', price: '$200', description: 'Nudim polovan telefon', status: 'Purchased' },
    { name: 'Advertisement 3', price: '$300', description: 'Nudim polovan televizor', status: 'Available' }
  ];
}