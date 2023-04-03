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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PokemonService } from './components/pokedexRedBlue/pokedexRedBlue.service';
import { PokedexPageComponent } from './components/pokedex-page/pokedex-page.component';
import { PokedexAddComponent } from './components/pokedex-add/pokedex-add.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { PokedexDeleteComponent } from './components/pokedex-delete/pokedex-delete.component';
import { PokedexUpdateComponent } from './components/pokedex-update/pokedex-update.component';
import { LoginComponent } from './components/login/login.component';
import { AuthService } from './components/auth/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './components/auth/authguard.service';
import { RegisterComponent } from './components/register/register.component';
import { AuthInterceptor } from './components/auth/authinterceptor.service';
import { AdminComponent } from './components/admin/admin.component';
import { AdminService } from './components/admin/admin.service';
import { UserPageComponent } from './components/user-page/user-page.component';
@NgModule({
  declarations: [
    AppComponent,
    PokedexRedBlueComponent,
    HomeComponent,
    PokedexPageComponent,
    PokedexAddComponent,
    PokedexDeleteComponent,
    PokedexUpdateComponent,
    LoginComponent,
    RegisterComponent,
    AdminComponent,
    UserPageComponent
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
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    PokemonService,
    AdminService,
    AuthService, 
    AuthGuard,
    {provide:HTTP_INTERCEPTORS, useClass:AuthInterceptor,multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
