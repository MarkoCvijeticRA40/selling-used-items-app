import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Advertisement } from '../../model/advertisement';
import { AdvertisementService } from '../../service/advertisement.service';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-create-advertisement',
  templateUrl: './create-advertisement.component.html',
  styleUrls: ['./create-advertisement.component.css']
})
export class CreateAdvertisementComponent {

  advertisement : Advertisement = new Advertisement();

  constructor(private router: Router, private advertisementService: AdvertisementService) { }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.advertisement.image = reader.result as string; 
    };
    reader.readAsDataURL(file);
  }

  navigateToAdvertisements() {
    this.router.navigate(['/home/advertisements']);
    console.log("here");
  }

  create() {
    //HARKODOVANO!
    this.advertisement.userId = 2;
    this.advertisementService.create(this.advertisement).pipe(
      catchError((error) => {
        console.error('Error fetching advertisements', error);
        return of([]);
      })
    ).subscribe((createdAdvertisement) => {
      if (createdAdvertisement) {
        alert('Advertisement created successfully!');
      } else {
        alert("Error during advertisement creation!");
      }
    });
  }

  onSubmit() {
    console.log(this.advertisement)
    if (!this.advertisement.name || !this.advertisement.price || !this.advertisement.description || !this.advertisement.location || !this.advertisement.image) {
      alert("You must enter all fields!");
      return;
    }
    this.create();
    this.router.navigate(['/home/advertisements']);
  }
}