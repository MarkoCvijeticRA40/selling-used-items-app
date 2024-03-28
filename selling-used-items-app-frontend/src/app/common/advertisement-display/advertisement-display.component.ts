import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementService } from '../../service/advertisement.service';
import { User } from '../../model/user';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-advertisement-display',
  templateUrl: './advertisement-display.component.html',
  styleUrls: ['./advertisement-display.component.css'] // Ispravite styleUrl u styleUrls
})
export class AdvertisementDisplayComponent implements OnInit {

  id : string = "";
  user: User = new User();

  advertisement: any = {
    commentaries: 'Great man! ★★★★★ - Dejan Dejanovic',
    contact: 'marko.cvijetic@vegait.rs'
  };
  

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private advertisementService : AdvertisementService, private userService: UserService) { }
  
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'] || '';
      console.log(this.id);
      this.advertisementService.get(parseInt(this.id)).subscribe(res => {
        this.advertisement = res;
        console.log(this.advertisement);
        console.log("ovo je user id", this.advertisement.userId);
        this.userService.get(this.advertisement.userId).subscribe(res => {
          this.user = res;
        });
      });
    });
  }
  
  navigateToAdvertisements(): void {
    this.router.navigate(['/home/advertisements']);
  }

  purchaseAdvertisement(): void {
    alert('Successfully purchased advertisement!');
    this.navigateToAdvertisements();
  }
}
