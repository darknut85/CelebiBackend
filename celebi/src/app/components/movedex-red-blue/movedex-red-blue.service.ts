import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Move } from 'src/app/objects/move';
import { AuthService } from '../auth/auth.service';
import { Delete } from 'src/app/objects/delete';
import { AdminService } from '../admin/admin.service';

@Injectable({
  providedIn: 'root'
})

export class MoveService {

    private apiURL = "https://localhost:7282";
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    constructor(private httpClient: HttpClient, private authService: AuthService, private adminService: AdminService) {}

    getMove(): Observable < Move[] > {
        return this.httpClient.get <Move[]> (this.apiURL + '/Move').pipe(catchError(this.adminService.errorHandler));
    }

    addMove(move: Move): Observable < Move > {
        return this.httpClient.post < Move > (this.apiURL + '/Move', JSON.stringify(move), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }
    
    getMoveByID(id: number): Observable < Move > {
        return this.httpClient.get < Move > (this.apiURL + '/Move/id?id=' + id).pipe(catchError(this.adminService.errorHandler))
    }

    updateMove(move: Move): Observable < Move > {
        return this.httpClient.put < Move > (this.apiURL + '/Move', JSON.stringify(move), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }

    removeMove(id: number): Observable < Delete>  {
        return this.httpClient.delete < Delete > (this.apiURL + '/Move/id?id=' + id, this.httpOptions).pipe(catchError(this.adminService.errorHandler));
    }
}