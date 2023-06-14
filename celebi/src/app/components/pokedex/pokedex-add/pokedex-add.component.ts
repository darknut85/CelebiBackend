import { Component, Inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Pokemon } from 'src/app/objects/pokemon';

@Component({
  selector: 'app-pokedex-add',
  templateUrl: './pokedex-add.component.html',
  styleUrls: ['./pokedex-add.component.css']
})
export class PokedexAddComponent {
  constructor(
    public dialogRef: MatDialogRef<PokedexAddComponent>,@Inject(MAT_DIALOG_DATA) public data: Pokemon){
  }
  onNoClick(): void{
    this.dialogRef.close();
  }
}
