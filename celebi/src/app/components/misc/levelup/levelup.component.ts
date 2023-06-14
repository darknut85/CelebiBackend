import { Component, Injectable } from '@angular/core';
import { LevelupMove } from 'src/app/objects/levelupMove';

@Component({
  selector: 'app-levelup',
  templateUrl: './levelup.component.html',
  styleUrls: ['./levelup.component.css']
})
export class LevelupComponent {
  @Injectable({
    providedIn: 'root'
  })
  levelup: LevelupMove = <LevelupMove>{ };
  title = 'celebi';
  message = "";

  constructor() { }
}
