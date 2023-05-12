import { Injectable } from '@angular/core';
import {CanActivate, Router, UrlTree} from '@angular/router';
import { Observable } from "rxjs";
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate 
{
    constructor(private authService: AuthService, private router: Router) { }

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