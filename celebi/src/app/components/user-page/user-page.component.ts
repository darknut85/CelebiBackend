import { Component } from '@angular/core';
import { AdminService } from '../admin/admin.service';
import { User } from 'src/app/objects/user';
import { ActivatedRoute } from '@angular/router';
import { Role } from 'src/app/objects/role';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
  constructor(private adminService: AdminService, private route: ActivatedRoute, private pokemonService: PokemonService) { }

  userName = "";
  uarray: User[] = [];
  user: User = 
  {
    userName: "",
    email: "",
    password: "",
    role: ""
  };
  message = "";

  ngOnInit()
  {
    this.userName = this.pokemonService.displayLogin();
      this.adminService.getUsers().subscribe((data: User[]) => {
      this.uarray = data;
    });
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.adminService.getUserByID(String(id)).subscribe((data: User) => { 
        this.user = data;
        this.adminService.getRoles(String(data.userName)).subscribe((role: Role) => {
          this.user.role = role.name;
        });
      });
    });
  }

  AddRole(): void
  {
    this.adminService.addRole(this.user.role,this.user.userName).subscribe((role: Role) => {
      this.message = role.name;
      console.log(this.message);
    });
  };
}
