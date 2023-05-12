import { Component, OnInit } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { ActivatedRoute } from '@angular/router';
import { Move } from 'src/app/objects/move';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';
import { LevelupMove } from 'src/app/objects/levelupMove';
import { LevelupService } from '../levelup/levelup.service';

@Component({
  selector: 'app-movedex-page',
  templateUrl: './movedex-page.component.html',
  styleUrls: ['./movedex-page.component.css']
})
export class MovedexPageComponent implements OnInit{
  constructor(private moveService: MoveService, private route: ActivatedRoute, private pokemonService: PokemonService,
    private levelupService: LevelupService) { }
  userName = "";
  selectedPokemon = 'selectedPokemon';
  lPokemon: Pokemon[] = [];
  parray: Pokemon[] = [];

  allPokemon: Pokemon[] = [];
  pokemon: Pokemon = <Pokemon>{ };
  level: number = 0;

  move: Move = {
    id: 0, name: "", type: "",
    powerPoints: 0, basePower: 0, accuracy: 0,
    battleEffect: "", 
    effectRate: 0, priority: 0, target: "",
    levelUpMoves: [{id: 0, level: 0, pokemonId: 0, moveId: 0}]
  }
  
  ngOnInit()
  {
    this.pokemonService.getPokemon().subscribe((data: Pokemon[]) => {
      this.parray = data;
      });
    this.userName = this.moveService.displayLogin();
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.moveService.getMoveByID(Number(id)).subscribe((data: Move) => 
      {
        if(data.levelUpMoves == null)
        {
          data.levelUpMoves = this.move.levelUpMoves;
        }
        else
        {
          data.levelUpMoves.forEach(levelup => {
            this.route.paramMap.subscribe(() =>
              { 
                this.pokemonService.getPokemonByID(Number(levelup.pokemonId)).subscribe((da: Pokemon) => 
                { 
                  this.lPokemon.push(da);
                });
              });
          });
        }
        this.move = data;
      });
    });
  }

  findPokemon(name: string): void{
    const pokemon = this.parray.find(x => x.name === name);
    if( pokemon != undefined)
    {
      this.pokemon = pokemon;
    }
  }

  addLevelupMove(): void{
    let levelUpMove: LevelupMove = {id: 0, pokemonId: this.pokemon.id, moveId: this.move.id, level: this.level}
    this.levelupService.addLevelupMove(levelUpMove).subscribe(() => {
      location.reload();
    });
  }
}
