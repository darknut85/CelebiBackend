import { Component, Inject, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Pokemon } from 'src/app/objects/pokemon';

@Component({
  selector: 'app-pokedex-add',
  templateUrl: './pokedex-add.component.html',
  styleUrls: ['./pokedex-add.component.css']
})
export class PokedexAddComponent {
  constructor(
    public dialogRef: MatDialogRef<PokedexAddComponent>,@Inject(MAT_DIALOG_DATA) public data: Pokemon){
  }
  
  currentPokemon = "";
  message = "";
  placeHolder = "";
  pokemon: Pokemon = <Pokemon>
  {
    id: 0, name: "", dexEntry: 0, 
    type1: "", type2: "", 
    height: 0, weight: 0,
    classification: "", pokedexEntry: "", growthRate: 0,
    hpev: 0, atkev: 0, defev: 0, spatkev: 0, spdefev: 0, spdev: 0,
    hp: 0, atk: 0, def: 0, spatk: 0, spdef: 0, spd: 0
  };

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
