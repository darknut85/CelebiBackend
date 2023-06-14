import { Injectable } from '@angular/core';
import {CanActivate, Router, UrlTree} from '@angular/router';
import { Observable } from "rxjs";
import { AuthService } from './auth.service';
import { AdminService } from '../admin/admin.service';
import { Role } from 'src/app/objects/role';

@Injectable()
export class AuthGuard implements CanActivate 
{
    constructor(private authService: AuthService, private router: Router, private adminService: AdminService) { }
    roles: Role[] = [];
    r: Role = {name: ""};
    isAdmin = false;

    canActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> 
    {
        const loggedIn = this.authService.isLoggedIn();
        if(!loggedIn)
        {
            this.router.navigate(['login']);
        }

        let userName = this.adminService.displayLogin();
        this.AuthorizedToView(userName);
        if(!this.isAdmin)
        {
            this.router.navigate(['home']);
        }

        return loggedIn;
    }

    AuthorizedToView(userName: string) {
        this.adminService.getRoles(String(userName)).subscribe((role: Role[]) => {
          role.forEach(element => {
            this.r = {name:element.toString()};
            this.roles.push(this.r);
          });
          this.roles.forEach(x => {
            if(x.name == "Admin"){
              this.isAdmin = true;
            }
          });
        });
      }
}