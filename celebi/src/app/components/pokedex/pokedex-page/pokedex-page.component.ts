import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pokemon } from 'src/app/objects/pokemon';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';
import { TypeMatchup } from 'src/app/objects/typeMatchups';
import { Move } from 'src/app/objects/move';
import { MoveService } from '../../movedex/movedex-red-blue/movedex-red-blue.service';
import { LevelupService } from '../../misc/levelup/levelup.service';
import { LevelupMove } from 'src/app/objects/levelupMove';
import { AdminService } from '../../users/admin/admin.service';
import { Role } from 'src/app/objects/role';

@Component({
  selector: 'app-pokedex-page',
  templateUrl: './pokedex-page.component.html',
  styleUrls: ['./pokedex-page.component.css']
})
export class PokedexPageComponent implements OnInit {
  
  constructor(private pokemonService: PokemonService, private route: ActivatedRoute, private moveService: MoveService,
    private levelupService: LevelupService, private adminService: AdminService) { }
  userName = "";
  selectedMove = 'selectedMove';
  marray: Move[] = [];
  typing1: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  typing2: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  typingFinal: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  lMoves: Move[] = [];
  tMoves: Move[] = [];
  move: Move = <Move>{ };
  level: number = 0;
  isVisible = false;
  roles: Role[] = [];
  r: Role = {name: ""};
  isTm: string = "false";

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
    levelUpMoves: [{id: 0, level: 0, pokemonId: 0, moveId: 0, isTm: false}]
  };
  ngOnInit()
  {
    this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
      });
    this.userName = this.adminService.displayLogin();
    this.AuthorizedToView(this.userName);
    this.addMoveToSelectionBox();
  }

  addMoveToSelectionBox(){
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
                  if(levelup.isTm == false)
                  {
                    this.lMoves.push(da);
                  }
                  else
                  {
                    this.tMoves.push(da);
                  }
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

  findMove(name: string): void{
    const move = this.marray.find(x => x.name === name);
    if( move != undefined)
    {
      this.move = move;
    }
  }

  findOwnedMove(id: string): void{
    const move = this.marray.find(x => x.id.toString() === id);
    if( move != undefined)
    {
      this.move = move;
    }
  }
  getMoveById(id:Number): string{
    const move = this.marray.find(x => x.id === id);
    if( move != undefined)
    {
      return move.name;
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
      levelUpMove.level = 0;
    }
    this.levelupService.addLevelupMove(levelUpMove).subscribe(response => {
      location.reload();
    });
  }

  removeLevelupMove(): void{

    let levelupMove = Number(this.selectedMove);
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