import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from './pokedexRedBlue.service';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PokedexAddComponent } from '../pokedex-add/pokedex-add.component';
import { Router } from '@angular/router';

@Component({
  selector: 'pokedexRedBlue-root',
  templateUrl: './pokedexRedBlue.component.html',
  styleUrls: ['./pokedexRedBlue.component.css']
})

export class PokedexRedBlueComponent implements OnInit {
  @Injectable({
    providedIn: 'root'
  })
  pokemon: Pokemon = <Pokemon>{ };
  title = 'celebi';
  constructor(private pokemonService: PokemonService, private dialog: MatDialog, private router: Router) { }

  parray: Pokemon[] = [];
  ngOnInit() {
      this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
      console.log("ngonInit()",data);
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(PokedexAddComponent, {
      data: {
        id: this.pokemon.id,
        name: this.pokemon.name, 
        dexEntry: this.pokemon.dexEntry, 
        type1: this.pokemon.type1, 
        type2: this.pokemon.type2, 
        height: this.pokemon.height, 
        weight: this.pokemon.weight,
        classification: this.pokemon.classification,
        pokedexEntry: this.pokemon.pokedexEntry
        },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.pokemon = result;
      console.log(result);
      this.addPokemon(result);
    });
  }

  //GET
  getPokemon(){
    this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
    });
  }

  //POST
  addPokemon(pokemon: Pokemon){
    this.pokemonService.addPokemon(pokemon).subscribe(response => {
      //Redirecting to user List page after save or update
      this.router.navigate(['/pokedexRedBlue']);
      
      console.log(response);
    });
  }

  /*
  //DELETE
  removePokemon(){
    this.pokemonService.removePokemon(id).subscribe(() => {
      this.refreshUser();
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