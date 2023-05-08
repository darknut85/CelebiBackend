import { Component, Injectable, OnInit } from '@angular/core';
import { Move } from 'src/app/objects/move';
import { MoveService } from './movedex-red-blue.service';

@Component({
  selector: 'app-movedex-red-blue',
  templateUrl: './movedex-red-blue.component.html',
  styleUrls: ['./movedex-red-blue.component.css']
})
export class MovedexRedBlueComponent implements OnInit {
  @Injectable({
    providedIn: 'root'
  })
  pokemon: Move = <Move>{ };
  title = 'celebi';

  constructor( private moveService: MoveService) { }

  marray: Move[] = [];
  userName = "";
  ngOnInit() {
      this.userName = this.moveService.displayLogin();
      this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
      console.log(data);
    });
  }

  //GET
  getMove(){
    this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
    });
  }
}
