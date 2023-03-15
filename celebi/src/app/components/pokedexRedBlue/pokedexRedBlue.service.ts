import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Pokemon } from 'src/app/objects/pokemon';

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
    constructor(private httpClient: HttpClient) {}

    getPokemon(): Observable < Pokemon[] > {
        return this.httpClient.get <Pokemon[]> (this.apiURL + '/Pokemon').pipe(catchError(this.errorHandler));
    }

    addPokemon(pokemon: Pokemon): Observable < Pokemon > {
        return this.httpClient.post < Pokemon > (this.apiURL + '/Pokemon', JSON.stringify(pokemon), this.httpOptions).pipe(catchError(this.errorHandler))
    }
    
    getPokemonByID(id: number): Observable < Pokemon > {
        return this.httpClient.get < Pokemon > (this.apiURL + '/Pokemon/id?id=' + id).pipe(catchError(this.errorHandler))
    }

    updatePokemon(pokemon: Pokemon): Observable < Pokemon > {
        return this.httpClient.put < Pokemon > (this.apiURL + '/Pokemon', JSON.stringify(pokemon), this.httpOptions).pipe(catchError(this.errorHandler))
    }

    removePokemon(id: number) {
        return this.httpClient.delete < Pokemon > (this.apiURL + '/Pokemon/id?id=' + id, this.httpOptions).pipe(catchError(this.errorHandler));
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