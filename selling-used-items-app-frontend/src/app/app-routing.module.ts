import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AppComponent } from './app.component';
import { AdvertisementDisplayComponent } from './common/advertisement-display/advertisement-display.component';
import { ProfileComponent } from './common/profile/profile.component';
import { ChangePasswordComponent } from './common/change-password/change-password.component';
import { HomeComponent } from './home/home.component';
import { EditProfileComponent } from './common/edit-profile/edit-profile.component';
import { MyAdvertisementComponent } from './common/my-advertisement/my-advertisement.component';
import { AllAdvertisementsComponent } from './common/all-advertisements/all-advertisements.component';
import { CreateAdvertisementComponent } from './common/create-advertisement/create-advertisement.component';
import { EditAdvertisementComponent } from './common/edit-advertisement/edit-advertisement.component';
import { ReportUserComponent } from './registered-user/report-user/report-user.component';
import { AllUsersComponent } from './administrator/all-users/all-users.component';
import { MyPurchaseComponent } from './common/my-purchase/my-purchase.component';
import { RateUserComponent } from './common/rate-user/rate-user.component';
import { AcceptDeclineCommentComponent } from './administrator/accept-decline-comment/accept-decline-comment.component';

const routes: Routes = [
  { 
    path: '', 
    component: AppComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent},
      { path: 'forgot-password', component: ForgotPasswordComponent},
      { 
        path: 'home', 
        component: HomeComponent,
        children: [ 
          { path: 'advertisements', component: AllAdvertisementsComponent },
          { path: 'advertisement/:id', component: AdvertisementDisplayComponent},     
          { path: 'create-advertisement', component: CreateAdvertisementComponent}, 
          { path: 'edit-advertisement/:id', component: EditAdvertisementComponent},
          { path: 'report-user', component: ReportUserComponent},
          { path: 'add-comment', component: RateUserComponent},
          { path: 'comments', component: AcceptDeclineCommentComponent},
          { path: 'profile', component: ProfileComponent,
          children: [
            { path: 'edit-profile', component: EditProfileComponent },
            { path: 'my-advertisements', component: MyAdvertisementComponent},
            { path: 'my-purchases', component: MyPurchaseComponent},
            { path: 'all-users', component: AllUsersComponent},
            { path: 'change-password', component: ChangePasswordComponent},
          ] 
        },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
