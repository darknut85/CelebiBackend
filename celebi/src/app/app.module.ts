import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/homepage/home/home.component'; 
import { PokedexRedBlueComponent } from './components/pokedex/pokedexRedBlue/pokedexRedBlue.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import {MatSelectModule} from '@angular/material/select';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PokemonService } from './components/pokedex/pokedexRedBlue/pokedexRedBlue.service';
import { PokedexPageComponent } from './components/pokedex/pokedex-page/pokedex-page.component';
import { PokedexAddComponent } from './components/pokedex/pokedex-add/pokedex-add.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { PokedexDeleteComponent } from './components/pokedex/pokedex-delete/pokedex-delete.component';
import { PokedexUpdateComponent } from './components/pokedex/pokedex-update/pokedex-update.component';
import { LoginComponent } from './components/users/login/login.component';
import { AuthService } from './components/users/auth/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './components/users/auth/authguard.service';
import { RegisterComponent } from './components/users/register/register.component';
import { AuthInterceptor } from './components/users/auth/authinterceptor.service';
import { AdminComponent } from './components/users/admin/admin.component';
import { AdminService } from './components/users/admin/admin.service';
import { UserPageComponent } from './components/users/user-page/user-page.component';
import { LogoutComponent } from './components/users/logout/logout.component';
import { FrontComponent } from './components/homepage/front/front.component';
import { MovedexRedBlueComponent } from './components/movedex/movedex-red-blue/movedex-red-blue.component';
import { MoveService } from './components/movedex/movedex-red-blue/movedex-red-blue.service';
import { MovedexPageComponent } from './components/movedex/movedex-page/movedex-page.component';
import { MovedexAddComponent } from './components/movedex/movedex-add/movedex-add.component';
import { MovedexUpdateComponent } from './components/movedex/movedex-update/movedex-update.component';
import { MovedexDeleteComponent } from './components/movedex/movedex-delete/movedex-delete.component';
import { LevelupComponent } from './components/misc/levelup/levelup.component';
import { LevelupService } from './components/misc/levelup/levelup.service';
import { ProfileComponent } from './components/users/profile/profile.component';
import { RoleGuard } from './components/users/auth/role-guard.service';
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
    UserPageComponent,
    LogoutComponent,
    FrontComponent,
    MovedexRedBlueComponent,
    MovedexPageComponent,
    MovedexAddComponent,
    MovedexUpdateComponent,
    MovedexDeleteComponent,
    LevelupComponent,
    ProfileComponent
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
    MoveService,
    LevelupService,
    AdminService,
    AuthService, 
    AuthGuard,
    RoleGuard,
    {provide:HTTP_INTERCEPTORS, useClass:AuthInterceptor,multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
