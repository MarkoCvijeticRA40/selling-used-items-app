import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../../service/purchase.service';
import { log } from 'console';
import { AdvertisementPurchaseDTO } from '../../dto/advertisementPurchasedto';

@Component({
  selector: 'app-my-purchase',
  templateUrl: './my-purchase.component.html',
  styleUrl: './my-purchase.component.css'
})
export class MyPurchaseComponent implements OnInit {

  loggedUserId : number = 2;

  loggedUserPurchasesInformation : AdvertisementPurchaseDTO[] = [];

  constructor(private purchaseService: PurchaseService) {

  }

  ngOnInit(): void {
    this.purchaseService.getByUserId(this.loggedUserId).subscribe((res) => {
      this.loggedUserPurchasesInformation = res;
    })
  }
}