import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokedexRedBlueComponent } from './components/pokedexRedBlue/pokedexRedBlue.component';
import { HomeComponent } from './components/home/home.component';
import { PokedexPageComponent } from './components/pokedex-page/pokedex-page.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './components/auth/authguard.service';
import { RegisterComponent } from './components/register/register.component';
import { AdminComponent } from './components/admin/admin.component';

const routes: Routes = [
  { path: '', redirectTo:'home', pathMatch: 'full'},
  { path: 'pokedexRedBlue', component: PokedexRedBlueComponent },
  { path: 'home', component: HomeComponent },
  { path: 'pokedexPage/:id', component: PokedexPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
