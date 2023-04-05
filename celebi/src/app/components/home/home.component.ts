import { Component } from '@angular/core';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private pokemonService: PokemonService){}
  userName = "";
  ngOnInit(): void {
    this.userName = this.pokemonService.displayLogin();
  }
}
