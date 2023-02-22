import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component'; 
import { PokedexRedBlueComponent } from './components/pokedexRedBlue/pokedexRedBlue.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import {MatSelectModule} from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { PokemonService } from './components/pokedexRedBlue/pokedexRedBlue.service';
import { PokedexPageComponent } from './components/pokedex-page/pokedex-page.component';
import { PokedexAddComponent } from './components/pokedex-add/pokedex-add.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { PokedexDeleteComponent } from './components/pokedex-delete/pokedex-delete.component';
import { PokedexUpdateComponent } from './components/pokedex-update/pokedex-update.component';

@NgModule({
  declarations: [
    AppComponent,
    PokedexRedBlueComponent,
    HomeComponent,
    PokedexPageComponent,
    PokedexAddComponent,
    PokedexDeleteComponent,
    PokedexUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatListModule,
    MatFormFieldModule,
    MatSelectModule,
    HttpClientModule,
    MatDialogModule,
    MatInputModule,
    FormsModule
  ],
  providers: [PokemonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
