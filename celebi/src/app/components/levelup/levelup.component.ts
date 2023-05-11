import { Component, Injectable, OnInit } from '@angular/core';
import { LevelupService } from './levelup.service';
import { LevelupMove } from 'src/app/objects/levelupMove';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

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

  constructor(private levelupService: LevelupService, private dialog: MatDialog, private router: Router) { }

  

}
