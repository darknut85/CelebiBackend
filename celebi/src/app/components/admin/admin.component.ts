import { Component, Injectable, OnInit } from '@angular/core';
import { User } from 'src/app/objects/user';
import { AdminService } from './admin.service';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit{
  @Injectable({
    providedIn: 'root'
  })
  pokemon: User = <User>{ };
  title = 'celebi';

  constructor(private adminService: AdminService, private pokemonService: PokemonService) { }

  uarray: User[] = [];
  userName = "";
  ngOnInit() {
    this.userName = this.pokemonService.displayLogin();
      this.adminService.getUsers().subscribe((data: User[]) => {
      this.uarray = data;
    });
  }
}
