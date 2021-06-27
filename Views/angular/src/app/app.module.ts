
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

import { ToastrModule } from 'ngx-toastr';
import { CautaDestinatiiComponent } from '../cauta-destinatii/cauta-destinatii.component';
import { ProfilComponent } from '../profil/profil.component';
import { ContactComponent } from '../contact/contact.component';
import { NotiteComponent } from '../notite/notite.component';
import { DespreComponent } from '../despre/despre.component';
import { RegisterComponent } from '../register/register.component';
import { LoginComponent } from '../login/login.component';
import { ClasamentComponent } from '../clasament/clasament.component';
import { PlanificariComponent } from '../planificari/planificari.component';


const appRoutes: Routes = [{ path: 'login', component: LoginComponent }];



@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    CautaDestinatiiComponent,
    ProfilComponent,
    ContactComponent,
    NotiteComponent,
    DespreComponent,
    ClasamentComponent,
    PlanificariComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot(
      appRoutes
    ),
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    CommonModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
