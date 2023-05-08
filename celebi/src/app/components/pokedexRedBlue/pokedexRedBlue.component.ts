import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from './pokedexRedBlue.service';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PokedexAddComponent } from '../pokedex-add/pokedex-add.component';
import { Router } from '@angular/router';
import { PokedexDeleteComponent } from '../pokedex-delete/pokedex-delete.component';
import { PokedexUpdateComponent } from '../pokedex-update/pokedex-update.component';
import { Delete } from 'src/app/objects/delete';

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
  message = "";

  constructor(private pokemonService: PokemonService, private dialog: MatDialog, private router: Router) { }

  parray: Pokemon[] = [];
  delete: Delete = {delete: false};
  userName = "";
  ngOnInit() {
      this.userName = this.pokemonService.displayLogin();
      this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
    });
  }

  openAddDialog(): void {
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
      this.pokemon = result;
      this.message = "You added " + this.pokemon.name;
      this.addPokemon(result);
    });
  }

  openDeleteDialog(): void{
    const dialogRef = this.dialog.open(PokedexDeleteComponent, {
      data: this.pokemon.id
    });

    dialogRef.afterClosed().subscribe(result => {
      this.pokemon.id = result;
      this.message = "You deleted " + this.pokemon.id;
      this.removePokemon(result);
    });
  }

  openUpdateDialog(): void{
    const dialogRef = this.dialog.open(PokedexUpdateComponent, {
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
      this.pokemon = result;
      this.message = "You updated " + this.pokemon.name;
      this.updatePokemon(result);
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
    this.pokemonService.addPokemon(pokemon).subscribe((response) => {
      this.router.navigate(['/pokedexRedBlue']);
      this.refresh();
    });
  }

  //PUT
  updatePokemon(pokemon: Pokemon){
    this.pokemonService.updatePokemon(pokemon).subscribe(response => {
      this.router.navigate(['/pokedexRedBlue']);
      this.refresh();
    });
  }

  //DELETE
  removePokemon(id: number){
    this.pokemonService.removePokemon(id).subscribe((data: Delete) => {
      this.delete = data;
      this.router.navigate(['/pokedexRedBlue']);
      this.refresh();
    });
  }
  
  refresh(): void{
    window.location.reload();
  }
}