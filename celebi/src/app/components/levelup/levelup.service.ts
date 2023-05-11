import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { Delete } from 'src/app/objects/delete';
import { LevelupMove } from 'src/app/objects/levelupMove';

@Injectable({
  providedIn: 'root'
})

export class LevelupService {

    private apiURL = "https://localhost:7282";
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    constructor(private httpClient: HttpClient, private authService: AuthService) {}

    getLevelupMove(): Observable < LevelupMove[] > {
        return this.httpClient.get <LevelupMove[]> (this.apiURL + '/Levelup').pipe(catchError(this.errorHandler));
    }

    addLevelupMove(levelupMove: LevelupMove): Observable < LevelupMove > {
        return this.httpClient.post < LevelupMove > (this.apiURL + '/Levelup', JSON.stringify(levelupMove), this.httpOptions).pipe(catchError(this.errorHandler))
    }
    
    getLevelupMoveByID(id: number): Observable < LevelupMove > {
        return this.httpClient.get < LevelupMove > (this.apiURL + '/Levelup/id?id=' + id).pipe(catchError(this.errorHandler))
    }

    updateLevelupMove(levelupMove: LevelupMove): Observable < LevelupMove > {
        return this.httpClient.put < LevelupMove > (this.apiURL + '/Levelup', JSON.stringify(levelupMove), this.httpOptions).pipe(catchError(this.errorHandler))
    }

    removeLevelupMove(id: number): Observable < Delete>  {
        return this.httpClient.delete < Delete > (this.apiURL + '/Levelup/id?id=' + id, this.httpOptions).pipe(catchError(this.errorHandler));
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

    displayLogin(): string
    {
        if(this.authService.isLoggedIn())
        {
            const token = localStorage.getItem("username");
            if(token != null)
            {
                return token;
            }
            return "";
        }
        return "";
    }
}