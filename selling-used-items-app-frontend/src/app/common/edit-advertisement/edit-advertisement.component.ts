import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-advertisement',
  templateUrl: './edit-advertisement.component.html',
  styleUrls: ['./edit-advertisement.component.css']
})
export class EditAdvertisementComponent {

  name = new FormControl('', Validators.required);
  price = new FormControl('', [Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]);
  description = new FormControl('', Validators.required);
  location = new FormControl('', Validators.required);

  advertisementForm = new FormGroup({
    name: this.name,
    price: this.price,
    description: this.description,
    location: this.location
  });

  constructor(private router: Router) { }

  // Implementiraj logiku za preuzimanje postojećeg oglasa i popunjavanje forme

  // Implementiraj logiku za brisanje oglasa ako je potrebno

  get nameError() {
    if (this.name.hasError('required')) {
      return 'Name is required';
    }
    return '';
  }

  get priceError() {
    if (this.price.hasError('required')) {
      return 'Price is required';
    }
    if (this.price.hasError('pattern')) {
      return 'Price must be a number with up to 2 decimal places';
    }
    return '';
  }

  get descriptionError() {
    if (this.description.hasError('required')) {
      return 'Description is required';
    }
    return '';
  }

  get locationError() {
    if (this.location.hasError('required')) {
      return 'Location is required';
    }
    return '';
  }

  navigateToAdvertisements() {
    this.router.navigate(['/home/profile/my-advertisements']);
  }

  onSubmit() {
    if (this.advertisementForm.valid) {
      alert("Form submitted successfully!");
      this.router.navigate(['/home/advertisements']);
    } else {
      console.log("Please correct the form errors.");
    }
  }
}
