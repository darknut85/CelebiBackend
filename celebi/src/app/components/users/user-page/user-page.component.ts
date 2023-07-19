import { Component } from '@angular/core';
import { AdminService } from '../admin/admin.service';
import { User } from 'src/app/objects/user';
import { ActivatedRoute } from '@angular/router';
import { Role } from 'src/app/objects/role';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
  constructor(private adminService: AdminService, private route: ActivatedRoute) { }

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
  roles: Role[] = [];

  ngOnInit()
  {
    this.userName = this.adminService.displayLogin();
      this.adminService.getUsers().subscribe((data: User[]) => {
      this.uarray = data;
    });
    this.AddUsersToSelectionBox();
  }

  AddUsersToSelectionBox(){
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.adminService.getUserByID(String(id)).subscribe((data: User) => { 
        this.user = data;
        this.adminService.getRoles(String(data.userName)).subscribe((role: Role[]) => {
          role.forEach(element => {
            this.roles.push({name:element.toString()});
          });
        });
      });
    });
  }

  AddRole(): void
  {
    this.adminService.addRole(this.user.role,this.user.userName).subscribe((role: Role) => {
      this.message = role.name;
      if(this.message == 'The role has been added to the user')
      {
        this.refresh();
      }
    });
  };

  RemoveRole(): void
  {
    this.adminService.removeRole(this.user.role,this.user.userName).subscribe((role: Role) => {
      this.message = role.name;
      if(this.message == 'The role has been removed from the user')
      {
        this.refresh();
      }
    });
  };

  refresh(): void{
    window.location.reload();
  }
}
