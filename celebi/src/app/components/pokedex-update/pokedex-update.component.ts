import { Component, Inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-pokedex-update',
  templateUrl: './pokedex-update.component.html',
  styleUrls: ['./pokedex-update.component.css']
})

export class PokedexUpdateComponent 
{
  constructor( private pokemonService: PokemonService,
              public dialogRef: MatDialogRef<PokedexUpdateComponent>, 
              @Inject(MAT_DIALOG_DATA) public data: Pokemon){
  }
  
  selectedPokemon = 'selectedPokemon';
  parray: Pokemon[] = [];
  pokemon: Pokemon = <Pokemon>{ };

  ngOnInit() {
    this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
    this.parray = data;
  });
  }
  
  findPokemon(name: string): void{
    const pokemon = this.parray.find(x => x.name === name);
    if( pokemon != undefined)
    {
      this.pokemon = pokemon;
    }
  }

  onNoClick(): void{
    this.dialogRef.close();
  }
}
