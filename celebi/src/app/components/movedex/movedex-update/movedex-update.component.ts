import { Component, Inject } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Move } from 'src/app/objects/move';

@Component({
  selector: 'app-movedex-update',
  templateUrl: './movedex-update.component.html',
  styleUrls: ['./movedex-update.component.css']
})
export class MovedexUpdateComponent 
  {
    constructor( private moveService: MoveService,
      public dialogRef: MatDialogRef<MovedexUpdateComponent>, 
      @Inject(MAT_DIALOG_DATA) public data: Move){}

  selectedMove = 'selectedMove';
  currentMove = "";
  marray: Move[] = [];
  move: Move = <Move>{ };
  message = "";

  ngOnInit() {
    this.moveService.getMove().subscribe((data: Move[]) => {
    this.marray = data;
    });
  }

  findMove(name: string): void{
    const move = this.marray.find(x => x.name === name);
    if( move != undefined)
    {
      this.move = move;
      this.currentMove = move.name;
    }
  }

  nameMade()
  {
    this.currentMove = this.data.name;
  }

  dataCheck()
  {
    this.message = "One or more fields must be a number";
    if(isNaN(this.move.powerPoints) || this.move.powerPoints.toString() == "")
    {
      return false;
    }
    if(isNaN(this.move.basePower) || this.move.basePower.toString() == "")
    {
      return false;
    }
    if(isNaN(this.move.accuracy) || this.move.accuracy.toString() == "")
    {
      return false;
    }
    if(isNaN(this.move.effectRate) || this.move.effectRate.toString() == "")
    {
      return false;
    }
    if(isNaN(this.move.priority) || this.move.priority.toString() == "")
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
