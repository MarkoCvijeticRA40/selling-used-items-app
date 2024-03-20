import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AppComponent } from './app.component';
import { AdvertisementDisplayComponent } from './common/advertisement-display/advertisement-display.component';

const routes: Routes = [
  { 
    path: '', 
    component: AppComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent},
      { path: 'forgot-password', component: ForgotPasswordComponent},
      { path: 'advertisement', component: AdvertisementDisplayComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
