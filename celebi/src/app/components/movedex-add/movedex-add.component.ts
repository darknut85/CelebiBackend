import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Move } from 'src/app/objects/move';

@Component({
  selector: 'app-movedex-add',
  templateUrl: './movedex-add.component.html',
  styleUrls: ['./movedex-add.component.css']
})
export class MovedexAddComponent {
  constructor(
    public dialogRef: MatDialogRef<MovedexAddComponent>,@Inject(MAT_DIALOG_DATA) public data: Move){
  }
  onNoClick(): void{
    this.dialogRef.close();
  }
}
