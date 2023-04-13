import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-pokedex-page',
  templateUrl: './pokedex-page.component.html',
  styleUrls: ['./pokedex-page.component.css']
})
export class PokedexPageComponent implements OnInit {
  
  constructor(private pokemonService: PokemonService, private route: ActivatedRoute) { }
  userName = "";
  pokemon: Pokemon = 
  {
    id: 0,
    name: "", 
    dexEntry: 0,
    classification: "",
    type1: "",
    type2: "",
    height: 0,
    weight: 0,
    pokedexEntry: ""
  };
  ngOnInit()
  {
    this.userName = this.pokemonService.displayLogin();
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.pokemonService.getPokemonByID(Number(id)).subscribe((data: Pokemon) => { this.pokemon = data; });
    });
  }
}
