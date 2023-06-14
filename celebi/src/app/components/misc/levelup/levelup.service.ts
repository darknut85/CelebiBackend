import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Delete } from 'src/app/objects/delete';
import { LevelupMove } from 'src/app/objects/levelupMove';
import { AdminService } from '../../users/admin/admin.service';

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
    constructor(private httpClient: HttpClient, private adminService: AdminService) {}

    getLevelupMove(): Observable < LevelupMove[] > {
        return this.httpClient.get <LevelupMove[]> (this.apiURL + '/Levelup').pipe(catchError(this.adminService.errorHandler));
    }

    addLevelupMove(levelupMove: LevelupMove): Observable < LevelupMove > {
        return this.httpClient.post < LevelupMove > (this.apiURL + '/Levelup', JSON.stringify(levelupMove), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }
    
    getLevelupMoveByID(id: number): Observable < LevelupMove > {
        return this.httpClient.get < LevelupMove > (this.apiURL + '/Levelup/id?id=' + id).pipe(catchError(this.adminService.errorHandler))
    }

    updateLevelupMove(levelupMove: LevelupMove): Observable < LevelupMove > {
        return this.httpClient.put < LevelupMove > (this.apiURL + '/Levelup', JSON.stringify(levelupMove), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }

    removeLevelupMove(id: number): Observable < Delete>  {
        return this.httpClient.delete < Delete > (this.apiURL + '/Levelup/id?id=' + id, this.httpOptions).pipe(catchError(this.adminService.errorHandler));
    }
}