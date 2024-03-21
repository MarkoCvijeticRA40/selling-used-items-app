import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AppComponent } from './app.component';
import { AdvertisementDisplayComponent } from './common/advertisement-display/advertisement-display.component';
import { HeaderBarComponent } from './common/header-bar/header-bar.component';
import { ProfileComponent } from './common/profile/profile.component';
import { ChangePasswordComponent } from './common/change-password/change-password.component';
import { HomeComponent } from './home/home.component';

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
          { 
            path: 'header', 
            component: HeaderBarComponent,
            children: [
              { path: 'advertisement', component: AdvertisementDisplayComponent },
              { path: 'profile', component: ProfileComponent },
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
