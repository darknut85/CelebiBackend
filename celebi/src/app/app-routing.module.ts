import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokedexRedBlueComponent } from './components/pokedexRedBlue/pokedexRedBlue.component';
import { HomeComponent } from './components/home/home.component';
import { PokedexPageComponent } from './components/pokedex-page/pokedex-page.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './components/auth/authguard.service';
import { RegisterComponent } from './components/register/register.component';
import { AdminComponent } from './components/admin/admin.component';
import { UserPageComponent } from './components/user-page/user-page.component';
import { LogoutComponent } from './components/logout/logout.component';
import { FrontComponent } from './components/front/front.component';
import { MovedexRedBlueComponent } from './components/movedex-red-blue/movedex-red-blue.component';
import { MovedexPageComponent } from './components/movedex-page/movedex-page.component';

const routes: Routes = [
  { path: 'front', component: FrontComponent },
  { path: '', redirectTo:'front', pathMatch: 'full'},
  { path: 'pokedexRedBlue', component: PokedexRedBlueComponent },
  { path: 'home', component: HomeComponent },
  { path: 'pokedexPage/:id', component: PokedexPageComponent },
  { path: 'movedexPage/:id', component: MovedexPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent},
  { path: 'userPage/:id', component: UserPageComponent,canActivate:[AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: 'movedexRedBlue', component: MovedexRedBlueComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
