import { Component, DoCheck, OnInit } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { ActivatedRoute } from '@angular/router';
import { Move } from 'src/app/objects/move';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../../pokedex/pokedexRedBlue/pokedexRedBlue.service';
import { LevelupService } from '../../misc/levelup/levelup.service';
import { AdminService } from '../../users/admin/admin.service';
import { Role } from 'src/app/objects/role';
import { LevelupMove } from 'src/app/objects/levelupMove';
import { LevelByEntry } from 'src/app/objects/levelByEntry';

@Component({
  selector: 'app-movedex-page',
  templateUrl: './movedex-page.component.html',
  styleUrls: ['./movedex-page.component.css']
})
export class MovedexPageComponent implements OnInit, DoCheck{
  constructor(private moveService: MoveService, private route: ActivatedRoute, private pokemonService: PokemonService,
    private levelupService: LevelupService, private adminService: AdminService) { }
  
  
  llevelByEntry: LevelByEntry[] = [];
  tlevelByEntry: LevelByEntry[] = [];
  lbe: LevelByEntry = {level: 0, dexEntry: 0};

  userName = "";
  selectedPokemon = 'selectedPokemon';
  lPokemon: Pokemon[] = [];
  tPokemon: Pokemon[] = [];
  lLevels: LevelupMove[] = [];
  tLevels: LevelupMove[] = [];

  parray: Pokemon[] = [];
  allPokemon: Pokemon[] = [];
  pokemon: Pokemon = <Pokemon>{ };
  level: number = 0;
  isVisible = false;
  roles: Role[] = [];
  r: Role = {name: ""};
  isTm: string = "false";

  move: Move = {
    id: 0, name: "", type: "",
    powerPoints: 0, basePower: 0, accuracy: 0,
    battleEffect: "", 
    effectRate: 0, priority: 0, target: "",
    levelUpMoves: [{id: 0, level: 0, pokemonId: 0, moveId: 0, isTm: false}]
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

  ngDoCheck(): void {
    this.tPokemon = this.tPokemon.sort((a,b) => a.dexEntry - b.dexEntry);
    this.lPokemon = this.lPokemon.sort((a,b) => a.dexEntry - b.dexEntry);
    this.llevelByEntry = this.llevelByEntry.sort((a,b) => a.level - b.level);
    this.tlevelByEntry = this.tlevelByEntry.sort((a,b) => a.level - b.level);
    this.llevelByEntry = this.llevelByEntry.sort((a,b) => a.dexEntry - b.dexEntry);
    this.tlevelByEntry = this.tlevelByEntry.sort((a,b) => a.dexEntry - b.dexEntry);
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
                  if(levelup.isTm == false)
                  {
                    this.lPokemon.push(da);
                    this.lLevels.push(levelup);
                    let a: LevelByEntry = {level: levelup.level, dexEntry: da.dexEntry};
                    this.llevelByEntry.push(a);
                  }
                  else
                  {
                    this.tPokemon.push(da);
                    this.tLevels.push(levelup);
                    let a: LevelByEntry = {level: levelup.level, dexEntry: da.dexEntry};
                    this.tlevelByEntry.push(a);
                  }
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

  addLevelupMove(isTm: string): void{
    let levelUpMove: LevelupMove = {id: 0, pokemonId: this.pokemon.id, moveId: this.move.id, level: this.level, isTm: false}
    if(isTm == "false")
    {
      levelUpMove.isTm = false;
    }
    else
    {
      levelUpMove.isTm = true;
    }
    this.levelupService.addLevelupMove(levelUpMove).subscribe(response => {
      location.reload();
    });
  }

  removeLevelupMove(): void{
    let levelupMove = Number(this.selectedPokemon);

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
