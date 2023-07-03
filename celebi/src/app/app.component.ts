import { Component, OnInit } from '@angular/core';
import { AuthService } from './components/users/auth/auth.service';
import { AdminService } from './components/users/admin/admin.service';
import { Role } from './objects/role';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'celebi';
  loggedIn = "";

  turnOn = false;
  turnOnAdmin = false;

  roles: Role[] = [];
  r: Role = {name: ""};
  isAdmin = false;

  constructor(private authService: AuthService, private adminService: AdminService) { }
  ngOnInit(): void {
    
    this.turnOn = this.authService.isLoggedIn();
    this.AuthorizedToView(this.adminService.displayLogin());
  }

  AuthorizedToView(userName: string) {
    this.adminService.getRoles(String(userName)).subscribe((role: Role[]) => {
      role.forEach(element => {
        this.r = {name:element.toString()};
        this.roles.push(this.r);
      });
      this.roles.forEach(x => {
        if(x.name == "Admin"){
          this.turnOnAdmin = true;
        }
      });
    });
  }
}
