import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Pokemon } from 'src/app/objects/pokemon';
import { Delete } from 'src/app/objects/delete';
import { AdminService } from '../../users/admin/admin.service';

@Injectable({
  providedIn: 'root'
})

export class PokemonService {

    private apiURL = "https://localhost:7282";
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    constructor(private httpClient: HttpClient, private adminService: AdminService) {}

    getPokemon(): Observable < Pokemon[] > {
        return this.httpClient.get <Pokemon[]> (this.apiURL + '/Pokemon').pipe(catchError(this.adminService.errorHandler));
    }

    addPokemon(pokemon: Pokemon): Observable < Pokemon > {
        return this.httpClient.post < Pokemon > (this.apiURL + '/Pokemon', JSON.stringify(pokemon), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }
    
    getPokemonByID(id: number): Observable < Pokemon > {
        return this.httpClient.get < Pokemon > (this.apiURL + '/Pokemon/id?id=' + id).pipe(catchError(this.adminService.errorHandler))
    }

    updatePokemon(pokemon: Pokemon): Observable < Pokemon > {
        return this.httpClient.put < Pokemon > (this.apiURL + '/Pokemon', JSON.stringify(pokemon), this.httpOptions).pipe(catchError(this.adminService.errorHandler))
    }

    removePokemon(id: number): Observable < Delete>  {
        return this.httpClient.delete < Delete > (this.apiURL + '/Pokemon/id?id=' + id, this.httpOptions).pipe(catchError(this.adminService.errorHandler));
    }
}