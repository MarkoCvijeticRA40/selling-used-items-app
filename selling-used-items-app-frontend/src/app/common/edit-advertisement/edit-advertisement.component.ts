import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Advertisement } from '../../model/advertisement';
import { AdvertisementService } from '../../service/advertisement.service';

@Component({
  selector: 'app-edit-advertisement',
  templateUrl: './edit-advertisement.component.html',
  styleUrls: ['./edit-advertisement.component.css']
})
export class EditAdvertisementComponent implements OnInit {

  advertisement : Advertisement = new Advertisement();

  id : number = 0;

  constructor(private router: Router, private advertisementService : AdvertisementService, private activatedRoute : ActivatedRoute) { }
  
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'] || '';
      this.advertisementService.get(this.id).subscribe(res => {
        this.advertisement = res;
      });
    });
  }
  
  navigateToAdvertisements() {
    this.router.navigate(['/home/profile/my-advertisements']);
  }

  onSubmit() {
    if (!this.advertisement.name || !this.advertisement.price || !this.advertisement.description || !this.advertisement.location) {
      alert("You must enter all fields!");
    } else {
      this.advertisementService.update(this.id, this.advertisement).subscribe(() => {
        alert("Advertisement updated successfully!");
      }, error => {
        console.error("Error updating advertisement:", error);
        alert("An error occurred while updating the advertisement. Please try again later.");
      });
    }
  }
  
}
