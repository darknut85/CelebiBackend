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
  oldPassword = "";
  newPassword = "";
  newUsername = "";
  roles: Role[] = [];

  ngOnInit()
  {
    this.userName = this.adminService.displayLogin();
    this.AddUsersToSelectionBox();
  }

  AddUsersToSelectionBox(){
    this.route.paramMap.subscribe(() =>
    { 
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

  ChangeUserName(){
    this.route.paramMap.subscribe(() =>
    { 
      this.adminService.updateUsername(this.userName, this.newUsername).subscribe((data: Role) => {
        location.reload();
      });
    });
  }

  ChangeMail(){
    this.route.paramMap.subscribe(() =>
    { 
      this.adminService.updateEmail(this.userName, this.newMail).subscribe((data: Role) => {
        location.reload();
      });
    });
  }

  ChangePassword(){
    this.route.paramMap.subscribe(() =>
    { 
      this.adminService.updatePassword(this.userName, this.oldPassword, this.newPassword).subscribe((data: Role) => {
        location.reload();
      });
    });
  }
}
