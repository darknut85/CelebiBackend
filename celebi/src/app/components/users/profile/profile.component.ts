import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin/admin.service';
import { User } from 'src/app/objects/user';
import { Role } from 'src/app/objects/role';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private adminService: AdminService, private route: ActivatedRoute){}

  userName = "";
  user: User = 
  {
    userName: "",
    email: "",
    password: "",
    role: ""
  };
  message = "";
  newMail = "";
  roles: Role[] = [];

  ngOnInit()
  {
    this.userName = this.adminService.displayLogin();
    this.AddUsersToSelectionBox();
  }

  AddUsersToSelectionBox(){
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.adminService.getSelf(this.userName).subscribe((data: User) => { 
        this.user = data;
        this.adminService.getRoles(String(data.userName)).subscribe((role: Role[]) => {
          role.forEach(element => {
            this.roles.push({name:element.toString()});
          });
        });
      });
    });
  }

  ChangeMail(){
    this.adminService.updateEmail(this.userName, this.newMail);
  }
}
