import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from 'src/app/objects/user';
import { Role } from 'src/app/objects/role';

@Injectable({
  providedIn: 'root'
})

export class AdminService {
    private apiURL = "https://localhost:7282/api/Token";
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    constructor(private httpClient: HttpClient) {}
    getUsers(): Observable < User[] > {
        return this.httpClient.get <User[]> (this.apiURL + '/GetAllUsers').pipe(catchError(this.errorHandler));
    }

    getUserByID(userName: string): Observable < User > {
        let params = new HttpParams().set('userName', userName);
        return this.httpClient.get < User > (this.apiURL + '/GetOneUser', { params }).pipe(catchError(this.errorHandler))
    }

    getRoles(userName: string): Observable < Role > {
        return this.httpClient.get < Role > (this.apiURL + '/GetRolesOfUser?userName=' + userName).pipe(catchError(this.errorHandler));
    }

    addRole(role: string, userName: string): Observable < Role >{
        let params = new HttpParams().set('role', role).set('userName', userName);
        return this.httpClient.get <Role> (this.apiURL + '/Roles', { params } ).pipe(catchError(this.errorHandler));
    }
    
    errorHandler(error: {
        error: {
            message: string;
        };status: any;message: any;
    }) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        return throwError(errorMessage);
    }
}