import { Component, OnInit } from '@angular/core';
import { MoveService } from '../movedex-red-blue/movedex-red-blue.service';
import { ActivatedRoute } from '@angular/router';
import { Move } from 'src/app/objects/move';

@Component({
  selector: 'app-movedex-page',
  templateUrl: './movedex-page.component.html',
  styleUrls: ['./movedex-page.component.css']
})
export class MovedexPageComponent implements OnInit{
  constructor(private moveService: MoveService, private route: ActivatedRoute) { }
  userName = "";

  move: Move = {
    id: 0, name: "", type: "",
    powerPoints: 0, basePower: 0, accuracy: 0,
    battleEffect: "", 
    effectRate: 0, priority: 0, target: ""
  }
  
  ngOnInit()
  {
    this.userName = this.moveService.displayLogin();
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.moveService.getMoveByID(Number(id)).subscribe((data: Move) => 
      { 
        this.move = data;
      });
    });
  }
}
