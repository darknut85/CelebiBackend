import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from './pokedexRedBlue.service';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PokedexAddComponent } from '../pokedex-add/pokedex-add.component';
import { Router } from '@angular/router';
import { PokedexDeleteComponent } from '../pokedex-delete/pokedex-delete.component';
import { PokedexUpdateComponent } from '../pokedex-update/pokedex-update.component';
import { AuthService } from '../auth/auth.service';

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

  constructor(private pokemonService: PokemonService, private dialog: MatDialog, private router: Router, private auth: AuthService) { }

  parray: Pokemon[] = [];
  ngOnInit() {
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
      console.log('The dialog was closed');
      this.pokemon = result;
      console.log(result);
      this.addPokemon(result);
    });
  }

  openDeleteDialog(): void{
    const dialogRef = this.dialog.open(PokedexDeleteComponent, {
      data: this.pokemon.id
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.pokemon.id = result;
      console.log(result);
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
      console.log('The dialog was closed');
      this.pokemon = result;
      console.log(result);
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
    this.pokemonService.addPokemon(pokemon).subscribe(response => {
      this.router.navigate(['/pokedexRedBlue']);
      this.refresh();
    });
  }

  
  //DELETE
  removePokemon(id: number){
    this.pokemonService.removePokemon(id).subscribe(response => {
      this.router.navigate(['/pokedexRedBlue']);
      this.refresh();
    });
  }

  //PUT
  updatePokemon(pokemon: Pokemon){
    this.pokemonService.updatePokemon(pokemon).subscribe(response => {
      this.router.navigate(['/pokemonRedBlue']);
      this.refresh();
    });
  }
  
  refresh(): void{
    window.location.reload();
  }
}