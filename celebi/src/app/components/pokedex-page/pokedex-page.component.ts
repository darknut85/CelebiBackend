import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';
import { TypeMatchup } from 'src/app/objects/typeMatchups';
import { Move } from 'src/app/objects/move';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';

@Component({
  selector: 'app-pokedex-page',
  templateUrl: './pokedex-page.component.html',
  styleUrls: ['./pokedex-page.component.css']
})
export class PokedexPageComponent implements OnInit {
  
  constructor(private pokemonService: PokemonService, private route: ActivatedRoute, private moveService: MoveService) { }
  userName = "";

  typing1: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  typing2: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  typingFinal: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  lMoves: Move[] = [];

  pokemon: Pokemon = 
  {
    id: 0,
    name: "", 
    dexEntry: 0,
    classification: "",
    type1: "", type2: "",
    height: 0, weight: 0,
    pokedexEntry: "",
    captureRate: 0,
    growthRate: 0,
    hp: 0, atk: 0, def: 0, spatk: 0, spdef: 0, spd: 0,
    hpev: 0, atkev: 0, defev: 0, spatkev: 0, spdefev: 0, spdev: 0,
    levelUpMoves: [{id: 0, level: 0, pokemonId: 0, moveId: 0}]
  };
  ngOnInit()
  {
    this.userName = this.pokemonService.displayLogin();
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.pokemonService.getPokemonByID(Number(id)).subscribe((data: Pokemon) => 
      {
        if(data.levelUpMoves == null)
        {
          data.levelUpMoves = this.pokemon.levelUpMoves;
        }
        else
        {
          data.levelUpMoves.forEach(levelup => {
            this.route.paramMap.subscribe(() =>
              { 
                this.moveService.getMoveByID(Number(levelup.moveId)).subscribe((da: Move) => 
                { 
                  this.lMoves.push(da);
                });
              });
          });
        }

        this.pokemon = data; 
        this.assignMatchups(data.type1, data.type2);
      });
    });
  }

  assignMatchups(type1: string, type2: string): void
  {
    this.typing1 = this.calculatetypes(type1);
    if(type2 != "")
    {
      this.typing2 = this.calculatetypes(type2);

      let count = 0;
      this.typing1.forEach(pokemonType => 
      {
        this.typingFinal[count] = pokemonType * this.typing2[count];
        count = count + 1;
      });
    }
    else
    {
      this.typingFinal = this.typing1;
    }
  }

  calculatetypes(type: string): number[]
  {
    let typeMatchup = new TypeMatchup();
    let typeName = typeMatchup.typeNames.indexOf(type);
    return typeMatchup.types[typeName];
  }
}

//current pokemon is selected pokemon
//allow to select a move for the current pokemon
//allow to enter move level
//button to send connection between move and pokemon to database