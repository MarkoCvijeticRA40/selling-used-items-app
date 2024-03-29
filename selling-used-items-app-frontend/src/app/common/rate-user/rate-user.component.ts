import { Component, OnInit } from '@angular/core';
import { CommentService } from '../../service/comment.service';
import { Comment } from '../../model/comment';
import { log } from 'console';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-rate-user',
  templateUrl: './rate-user.component.html',
  styleUrl: './rate-user.component.css'
})
export class RateUserComponent implements OnInit {
  
  loggedUserId : number = 2;

  comment: Comment = new Comment();

  constructor(private commentService: CommentService) { }
  
  ngOnInit(): void {
    
  }

  create() {
    const checkedStars = document.querySelectorAll('input[name="rating"]:checked').length;
    this.comment.rating = checkedStars;
    this.comment.creatorId = this.loggedUserId;
    console.log(`Number of yellow stars: ${checkedStars}`);
    
    this.commentService.createComment(this.comment)
        .pipe(
            catchError((error) => {
                alert('Purchase with this id does not exist');
                console.error(error);
                return of(error); // Morate emitirati nešto kako biste zadržali observable lanac
            })
        )
        .subscribe((res) => {
            // Ovdje možete dodati bilo kakvu logiku za obradu uspješnog odgovora
        });
  } 
}