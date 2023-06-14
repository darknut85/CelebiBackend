import { Component, Inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-pokedex-delete',
  templateUrl: './pokedex-delete.component.html',
  styleUrls: ['./pokedex-delete.component.css']
})
export class PokedexDeleteComponent 
{
  constructor(private pokemonService: PokemonService,
                      public dialogRef: MatDialogRef<PokedexDeleteComponent>,
                      @Inject(MAT_DIALOG_DATA) public data: Pokemon)
    {}
  
  selectedPokemon = 'selectedPokemon';
  parray: Pokemon[] = [];
  pokemonId: number = -1;

  ngOnInit() {
      this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
    });
  }

  findId(name: string): void{
    const pokemon = this.parray.find(x => x.name === name);
    if( pokemon != undefined)
    {
      this.pokemonId = pokemon.id;
    }
  }

  onNoClick(): void{
    this.dialogRef.close();
  }
}
