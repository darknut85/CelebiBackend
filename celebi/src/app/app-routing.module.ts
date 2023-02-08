import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PokedexRedBlueComponent } from './components/pokedexRedBlue/pokedexRedBlue.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'pokedexRedBlue', component: PokedexRedBlueComponent },
  { path: 'home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
