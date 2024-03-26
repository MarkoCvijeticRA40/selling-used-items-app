import { Injectable } from '@angular/core';
import { Comment } from '../model/comment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private baseUrl = 'http://localhost:5152/api/comments'; // URL tvog backend-a

  constructor(private http: HttpClient) { }

  getAllComments(): Observable<Comment[]> {
    return this.http.get<Comment[]>(this.baseUrl);
  }

  getCommentById(commentId: number): Observable<Comment> {
    const url = `${this.baseUrl}/${commentId}`;
    return this.http.get<Comment>(url);
  }

  createComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(this.baseUrl, comment);
  }

  updateComment(comment: Comment): Observable<Comment> {
    const url = `${this.baseUrl}/${comment.id}`;
    return this.http.put<Comment>(url, comment);
  }

  deleteComment(commentId: number): Observable<void> {
    const url = `${this.baseUrl}/${commentId}`;
    return this.http.delete<void>(url);
  }

  getAllCommentsByTargetUserId(targetUserId: number): Observable<Comment[]> {
    const url = `${this.baseUrl}/targetUserId/${targetUserId}`;
    return this.http.get<Comment[]>(url);
  }
}