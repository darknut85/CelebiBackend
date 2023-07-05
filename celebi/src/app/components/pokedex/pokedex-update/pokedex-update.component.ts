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
  currentPokemon = "";
  message = "";

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
      this.currentPokemon = pokemon.name;
    }
  }

  nameMade()
  {
    this.currentPokemon = this.pokemon.name;
  }

  dataCheck()
  {
    this.message = "One or more fields must be a number";
    if(isNaN(this.pokemon.dexEntry) || this.pokemon.dexEntry.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.height) || this.pokemon.height.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.weight) || this.pokemon.weight.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.growthRate) || this.pokemon.growthRate.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.hpev) || this.pokemon.hpev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.atkev) || this.pokemon.atkev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.defev) || this.pokemon.defev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spatkev) || this.pokemon.spatkev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spdefev) || this.pokemon.spdefev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spdev) || this.pokemon.spdev.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.hp) || this.pokemon.hp.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.atk) || this.pokemon.atk.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.def) || this.pokemon.def.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spatk) || this.pokemon.spatk.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spdev)  || this.pokemon.spdef.toString() == "")
    {
      return false;
    }
    if(isNaN(this.pokemon.spd)  || this.pokemon.spd.toString() == "")
    {
      return false;
    }
    this.message = "";
    return true;
  }

  onNoClick(): void{
    this.dialogRef.close();
  }
}
