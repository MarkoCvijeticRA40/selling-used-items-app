import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementService } from '../../service/advertisement.service';
import { User } from '../../model/user';
import { UserService } from '../../service/user.service';
import { CommentService } from '../../service/comment.service';
import { catchError, of, switchMap } from 'rxjs';
import { Advertisement } from '../../model/advertisement';
import { log } from 'node:console';
import { AuthorizationService } from '../../service/authorization.service';

@Component({
  selector: 'app-advertisement-display',
  templateUrl: './advertisement-display.component.html',
  styleUrls: ['./advertisement-display.component.css']
})
export class AdvertisementDisplayComponent implements OnInit {

  id : string = "";
  user: User = new User();
  comments: any;
  advertisement: Advertisement = new Advertisement();
  loggedUserId: number = 0;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private authorizationService: AuthorizationService, private advertisementService : AdvertisementService, private userService: UserService, private commentService: CommentService) { }
  
  ngOnInit(): void {
    this.activatedRoute.params.pipe(
      switchMap(params => {
        this.id = params['id'] || '';
        console.log(this.id);
        return this.advertisementService.get(parseInt(this.id));
      }),
      switchMap(advertisement => {
        this.advertisement = advertisement;
        console.log(this.advertisement);
        console.log("ovo je user id", this.advertisement.userId);
        return this.userService.get(this.advertisement.userId);
      }),
      switchMap(user => {
        this.user = user;
        return this.commentService.getAllCommentsByTargetUserId(this.user.id);
      }),
      catchError(error => {
        console.error("Error fetching data", error);
        return of([]);
      })
    ).subscribe(comments => {
      this.comments = comments;
    });

    const userId = this.authorizationService.getUserID();
    if (userId !== null) {
      this.loggedUserId = userId;
      this.userService.get(this.loggedUserId).pipe(
      catchError((error) => {
      console.error('Error fetching user', error);
      return of(null); 
    })
    ).subscribe(res => {
    if (res) { 
      this.user = res; 
          }
        });
      } 
    }

  reserve() {
    this.advertisement.advertisementStatus = 1;
    this.advertisement.reservedBy = this.loggedUserId;
    this.advertisementService.update(this.advertisement.id,this.advertisement).subscribe((res) => {
    });
    this.router.navigate(['/home/advertisements']);
  }
  
  navigateToAdvertisements(): void {
    this.router.navigate(['/home/advertisements']);
  }

  purchaseAdvertisement(): void {
    this.reserve();
    alert('Successfully purchased advertisement!');
    this.navigateToAdvertisements();
  }
}