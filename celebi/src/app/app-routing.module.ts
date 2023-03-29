import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PokedexRedBlueComponent } from './components/pokedexRedBlue/pokedexRedBlue.component';
import { HomeComponent } from './components/home/home.component';
import { PokedexPageComponent } from './components/pokedex-page/pokedex-page.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './components/auth/authguard.service';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'pokedexRedBlue', component: PokedexRedBlueComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent },
  { path: 'pokedexPage/:id', component: PokedexPageComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
