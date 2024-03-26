import { Component } from '@angular/core';

@Component({
  selector: 'app-rate-user',
  templateUrl: './rate-user.component.html',
  styleUrl: './rate-user.component.css'
})
export class RateUserComponent {

  onSubmit() {
    const checkedStars = document.querySelectorAll('input[name="rating"]:checked').length;
    console.log(`Number of yellow stars: ${checkedStars}`);
  }
}