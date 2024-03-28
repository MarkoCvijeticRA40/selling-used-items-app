import { Injectable } from '@angular/core';
import { Comment } from '../model/comment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Comment[]> {
    return this.http.get<Comment[]>('http://localhost:5152/api/comments');
  }

  getCommentById(commentId: number): Observable<Comment> {
    return this.http.get<Comment>(`http://localhost:5152/api/comments/${commentId}`);
  }

  createComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>('http://localhost:5152/api/comments', comment);
  }

  updateComment(comment: Comment): Observable<Comment> {
    return this.http.put<Comment>(`http://localhost:5152/api/comments/${comment.id}`, comment);
  }

  deleteComment(commentId: number): Observable<void> {
    return this.http.delete<void>(`http://localhost:5152/api/comments/${commentId}`);
  }

  getAllCommentsByTargetUserId(targetUserId: number): Observable<Comment[]> {
    return this.http.get<Comment[]>(`http://localhost:5152/api/comments/target-user/${targetUserId}`);
  }

  approve(commentId: number): Observable<void> {
    return this.http.put<void>(`http://localhost:5152/api/comments/approve/${commentId}`, null);
  }

  decline(commentId: number): Observable<void> {
    return this.http.put<void>(`http://localhost:5152/api/comments/decline/${commentId}`, null);
  }
}
