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

    userCanActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>
    {
      const loggedIn = this.authService.isLoggedIn();
      if(!loggedIn)
      {
          this.router.navigate(['login']);
      }

      return loggedIn;
    }

    canActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> 
    {
        const loggedIn = this.authService.isLoggedIn();
        if(!loggedIn)
        {
            this.router.navigate(['login']);
        }

        return loggedIn;
    }
}