import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from 'src/app/objects/user';

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
        return this.httpClient.get < User > (this.apiURL + '/GetOneUser/userName?userName=' + userName).pipe(catchError(this.errorHandler))
    }

    removeUser(userName: string) {
        return this.httpClient.delete < User > (this.apiURL + '/Pokemon/userName?userName=' + userName, this.httpOptions).pipe(catchError(this.errorHandler));
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