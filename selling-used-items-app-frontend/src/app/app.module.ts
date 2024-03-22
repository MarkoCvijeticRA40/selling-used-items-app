import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RouterModule } from '@angular/router';
import { AdvertisementDisplayComponent } from './common/advertisement-display/advertisement-display.component';
import { ProfileComponent } from './common/profile/profile.component';
import { ChangePasswordComponent } from './common/change-password/change-password.component';
import { HomeComponent } from './home/home.component';
import { EditProfileComponent } from './common/edit-profile/edit-profile.component';
import { MyAdvertisementComponent } from './common/my-advertisement/my-advertisement.component';
import { AllAdvertisementsComponent } from './common/all-advertisements/all-advertisements.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    AdvertisementDisplayComponent,
    ProfileComponent,
    ChangePasswordComponent,
    HomeComponent,
    EditProfileComponent,
    MyAdvertisementComponent,
    AllAdvertisementsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
