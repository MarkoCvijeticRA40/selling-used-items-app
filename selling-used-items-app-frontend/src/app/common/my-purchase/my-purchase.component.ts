import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../../service/purchase.service';
import { log } from 'console';
import { AdvertisementPurchaseDTO } from '../../dto/advertisementPurchasedto';
import { AuthorizationService } from '../../service/authorization.service';
import { UserService } from '../../service/user.service';
import { catchError, of } from 'rxjs';
import { User } from '../../model/user';

@Component({
  selector: 'app-my-purchase',
  templateUrl: './my-purchase.component.html',
  styleUrl: './my-purchase.component.css'
})
export class MyPurchaseComponent implements OnInit {

  userId : number = 0;

  loggedUserPurchasesInformation : AdvertisementPurchaseDTO[] = [];

  user : User = new User();

  constructor(private purchaseService: PurchaseService, private authorizationService: AuthorizationService, private userService: UserService) { }

  ngOnInit(): void {
    const userId = this.authorizationService.getUserID();
    if (userId !== null) {
      this.userId = userId;
    }  
    this.purchaseService.getByUserId(this.userId).subscribe((res) => {
        this.loggedUserPurchasesInformation = res;
    })
  }
}