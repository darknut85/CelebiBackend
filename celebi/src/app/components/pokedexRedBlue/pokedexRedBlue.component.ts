import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from './pokedexRedBlue.service';
import { Injectable } from '@angular/core';

@Component({
  selector: 'pokedexRedBlue-root',
  templateUrl: './pokedexRedBlue.component.html',
  styleUrls: ['./pokedexRedBlue.component.css']
})
export class PokedexRedBlueComponent implements OnInit {
  @Injectable({
    providedIn: 'root'
  })
  title = 'celebi';
  constructor(private pokemonService: PokemonService) { }
  
  parray: Pokemon[] = [];
  ngOnInit() {
      this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
      console.log("ngonInit()",data);
    });
  }

  //GET
  getPokemon(){
    this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
    });
  }
  /*
  //DELETE
  removePokemon(){
    this.pokemonService.removePokemon(id).subscribe(() => {
      this.refreshUser();
    });
  }

  //POST
  addPokemon(){
    this.pokemonService.addPokemon(this.pokemonform.value).subscribe((data: Pokemon) => {
      //Redirecting to user List page after save or update
      this.router.navigate(['/pokemon']);
    });
  }

  
  //PUT
  updatePokemon(){
    this.pokemonService.updatePokemon(this.pokemonform.value).subscribe((data: Pokemon) => {
      //Redirecting to user List page after save or update
      this.router.navigate(['/pokemon']);
    });
  }
  */
}