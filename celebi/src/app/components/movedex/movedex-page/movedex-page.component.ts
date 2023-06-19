import { Component, OnInit } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { ActivatedRoute } from '@angular/router';
import { Move } from 'src/app/objects/move';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../../pokedex/pokedexRedBlue/pokedexRedBlue.service';
import { LevelupService } from '../../misc/levelup/levelup.service';
import { AdminService } from '../../users/admin/admin.service';
import { Role } from 'src/app/objects/role';

@Component({
  selector: 'app-movedex-page',
  templateUrl: './movedex-page.component.html',
  styleUrls: ['./movedex-page.component.css']
})
export class MovedexPageComponent implements OnInit{
  constructor(private moveService: MoveService, private route: ActivatedRoute, private pokemonService: PokemonService,
    private levelupService: LevelupService, private adminService: AdminService) { }
  userName = "";
  selectedPokemon = 'selectedPokemon';
  lPokemon: Pokemon[] = [];
  parray: Pokemon[] = [];

  allPokemon: Pokemon[] = [];
  pokemon: Pokemon = <Pokemon>{ };
  level: number = 0;
  isVisible = false;
  roles: Role[] = [];
  r: Role = {name: ""};

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

    this.userName = this.adminService.displayLogin();
    this.AuthorizedToView(this.userName);
    this.addPokemonToSelectionBox();
  }

  addPokemonToSelectionBox(): void{
    this.route.paramMap.subscribe((params) =>
    { 
      this.moveService.getMoveByID(Number(params.get('id'))).subscribe((data: Move) => 
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

  findOwnedPokemon(id: string): void{
    const pokemon = this.parray.find(x => x.id.toString() === id);
    if( pokemon != undefined)
    {
      this.pokemon = pokemon;
    }
  }

  getPokemonById(id:Number): string{
    const pokemon = this.parray.find(x => x.id === id);
    if( pokemon != undefined)
    {
      return pokemon.name;
    }
    return "";
  }

  addLevelupMove(): void{
    this.levelupService.addLevelupMove(
      {
        id: 0, 
        pokemonId: this.pokemon.id, 
        moveId: this.move.id, 
        level: this.level
      }).subscribe(() => {
      location.reload();
    });
  }

  removeLevelupMove(): void{

    let levelupMove = this.pokemon.levelUpMoves.find(x => x.moveId == this.move.id && x.pokemonId == this.pokemon.id)?.id
    console.log(this.pokemon.id);
    console.log(this.move.id);
    console.log(levelupMove)
    if(levelupMove != undefined)
    {
      this.levelupService.removeLevelupMove(levelupMove).subscribe(response => {
        location.reload();
      });
    }
  }

  AuthorizedToView(userName: string) {
    this.adminService.getRoles(String(userName)).subscribe((role: Role[]) => {
      role.forEach(element => {
        this.r = {name:element.toString()};
        this.roles.push(this.r);
      });
      this.roles.forEach(x => {
        if(x.name == "Admin"){
          this.isVisible = true;
        }
      });
    });
  }
}
