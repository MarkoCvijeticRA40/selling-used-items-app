import { Component, OnInit } from '@angular/core';
import { CommentService } from '../../service/comment.service';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-accept-decline-comment',
  templateUrl: './accept-decline-comment.component.html',
  styleUrl: './accept-decline-comment.component.css'
})
export class AcceptDeclineCommentComponent implements OnInit {

  comments : any;

  constructor(private commentService: CommentService) {

  }

  ngOnInit(): void {
    this.fetchComments();
  }

  fetchComments() {
    this.commentService.getAll().pipe(
      catchError((error) => {
        console.error("Error fetching comments", error);
        return of([]);
      })
    ).subscribe(res => {
      this.comments = res;
      console.log(this.comments);
    });
}

  approveComment(id: number) {
    this.commentService.approve(id).subscribe(() => {
      alert("Comment successfully approved!");
      this.fetchComments();
    });
  }
  
  declineComment(id: number) {
    this.commentService.decline(id).subscribe(() => {
      alert("Comment successfully declined!");
      this.fetchComments();
    });
  }
}
