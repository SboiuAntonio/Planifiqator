import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CautaDestinatiiComponent } from '../cauta-destinatii/cauta-destinatii.component';
import { ClasamentComponent } from '../clasament/clasament.component';
import { ContactComponent } from '../contact/contact.component';
import { DespreComponent } from '../despre/despre.component';
import { LoginComponent } from '../login/login.component';
import { NotiteComponent } from '../notite/notite.component';
import { PlanificariComponent } from '../planificari/planificari.component';
import { ProfilComponent } from '../profil/profil.component';
import { RegisterComponent } from '../register/register.component';

const routes: Routes = [{ path: 'login', component: LoginComponent },
  { path: 'profil', component: ProfilComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'notite', component: NotiteComponent},
  { path: 'cauta-destinatii', component: CautaDestinatiiComponent},
  { path: 'contact', component: ContactComponent },
  { path: 'despre', component: DespreComponent },
  { path: 'planificari', component: PlanificariComponent },
  { path: 'clasament', component: ClasamentComponent },
  { path: '**', component: LoginComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
