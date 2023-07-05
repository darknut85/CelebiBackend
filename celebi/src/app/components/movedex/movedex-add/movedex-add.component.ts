import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Move } from 'src/app/objects/move';

@Component({
  selector: 'app-movedex-add',
  templateUrl: './movedex-add.component.html',
  styleUrls: ['./movedex-add.component.css']
})
export class MovedexAddComponent {

  currentMove = "";
  message = "";
  move: Move = <Move>{
    id: 0, name: "", type: "", 
    powerPoints: 0, basePower: 0, accuracy: 0, 
    battleEffect: "", effectRate: 0, priority: 0, target: ""
  }
  constructor(
    public dialogRef: MatDialogRef<MovedexAddComponent>,@Inject(MAT_DIALOG_DATA) public data: Move){
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
