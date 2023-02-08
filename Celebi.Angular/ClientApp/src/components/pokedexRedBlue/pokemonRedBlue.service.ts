import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PokedexRedBlueService {
  constructor(private http: HttpClient) { }
}