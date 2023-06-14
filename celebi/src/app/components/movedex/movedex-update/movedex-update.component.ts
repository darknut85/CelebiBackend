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
  marray: Move[] = [];
  move: Move = <Move>{ };

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
    }
  }

  onNoClick(): void{
    this.dialogRef.close();
  }
}
