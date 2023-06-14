import { Component, Inject } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Move } from 'src/app/objects/move';

@Component({
  selector: 'app-movedex-delete',
  templateUrl: './movedex-delete.component.html',
  styleUrls: ['./movedex-delete.component.css']
})
export class MovedexDeleteComponent {

    constructor(private moveService: MoveService,
      public dialogRef: MatDialogRef<MovedexDeleteComponent>,
      @Inject(MAT_DIALOG_DATA) public data: Move)
  {}

  selectedMove = 'selectedMove';
  marray: Move[] = [];
  moveId: number = -1;

  ngOnInit() {
    this.moveService.getMove().subscribe((data: Move[]) => {
    this.marray = data;
    });
  }

  findId(name: string): void{
    const move = this.marray.find(x => x.name === name);
    if( move != undefined)
    {
      this.moveId = move.id;
    }
  }

  onNoClick(): void{
  this.dialogRef.close();
  }
}
