import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokedexRedBlueComponent } from './components/pokedex/pokedexRedBlue/pokedexRedBlue.component';
import { HomeComponent } from './components/homepage/home/home.component';
import { PokedexPageComponent } from './components/pokedex/pokedex-page/pokedex-page.component';
import { LoginComponent } from './components/users/login/login.component';
import { AuthGuard } from './components/users/auth/authguard.service';
import { RegisterComponent } from './components/users/register/register.component';
import { AdminComponent } from './components/users/admin/admin.component';
import { UserPageComponent } from './components/users/user-page/user-page.component';
import { LogoutComponent } from './components/users/logout/logout.component';
import { FrontComponent } from './components/homepage/front/front.component';
import { MovedexRedBlueComponent } from './components/movedex/movedex-red-blue/movedex-red-blue.component';
import { MovedexPageComponent } from './components/movedex/movedex-page/movedex-page.component';
import { ProfileComponent } from './components/users/profile/profile.component';
import { RoleGuard } from './components/users/auth/role-guard.service';

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
  { path: 'userPage/:id', component: UserPageComponent,canActivate:[RoleGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [RoleGuard] },
  { path: 'movedexRedBlue', component: MovedexRedBlueComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
