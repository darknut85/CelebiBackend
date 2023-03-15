import { Injectable } from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree} from '@angular/router';
import { Observable } from "rxjs";
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate 
{
    
    constructor(private authService: AuthService, private router: Router) {
        
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> 
    {
        if(this.authService.isLoggedIn())
        {
            return true;
        }
        else
        {
            this.router.navigate(['login']);
            return false;
        }
    }
}