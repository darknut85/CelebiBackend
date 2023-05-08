import { Component, Injectable, OnInit } from '@angular/core';
import { Move } from 'src/app/objects/move';
import { MoveService } from './movedex-red-blue.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MovedexAddComponent } from '../movedex-add/movedex-add.component';

@Component({
  selector: 'app-movedex-red-blue',
  templateUrl: './movedex-red-blue.component.html',
  styleUrls: ['./movedex-red-blue.component.css']
})
export class MovedexRedBlueComponent implements OnInit {
  @Injectable({
    providedIn: 'root'
  })
  move: Move = <Move>{ };
  title = 'celebi';

  constructor( private moveService: MoveService, private dialog: MatDialog, private router: Router) { }

  marray: Move[] = [];
  userName = "";
  ngOnInit() {
      this.userName = this.moveService.displayLogin();
      this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
      console.log(data);
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(MovedexAddComponent, {
      data: {
        id: this.move.id,
        name: this.move.name, 
        },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.move = result;
      console.log(result);
      this.addPokemon(result);
    });
  }

  //GET
  getMove(){
    this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
    });
  }

  //POST
  addPokemon(move: Move){
    this.moveService.addMove(move).subscribe((response) => {
      this.router.navigate(['/movedexRedBlue']);
      this.refresh();
    });
  }

  refresh(): void{
    window.location.reload();
  }
}
