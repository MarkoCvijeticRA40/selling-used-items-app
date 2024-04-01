import { Component, OnInit } from '@angular/core';
import { CommentService } from '../../service/comment.service';
import { Comment } from '../../model/comment';
import { log } from 'console';
import { catchError, of } from 'rxjs';
import { AuthorizationService } from '../../service/authorization.service';

@Component({
  selector: 'app-rate-user',
  templateUrl: './rate-user.component.html',
  styleUrl: './rate-user.component.css'
})
export class RateUserComponent implements OnInit {
  
  userId : number = 0;

  comment: Comment = new Comment();

  constructor(private commentService: CommentService, private authorizationService: AuthorizationService) { }
  
  ngOnInit(): void {
    const userId = this.authorizationService.getUserID();
    if (userId !== null) {
      this.userId = userId;
    }  
  }

  create() {
    const checkedStars = document.querySelectorAll('input[name="rating"]:checked').length;
    this.comment.rating = checkedStars;
    this.comment.creatorId = this.userId;
    console.log(`Number of yellow stars: ${checkedStars}`);
    
    this.commentService.createComment(this.comment)
        .pipe(
            catchError((error) => {
                alert('Purchase with this id does not exist');
                console.error(error);
                return of(error); 
            })
        )
        .subscribe((res) => {
        });
  } 
}