import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/objects/user';
import { AdminService } from './admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit{

  constructor(private adminService: AdminService) { }

  uarray: User[] = [];
  userName = "";
  ngOnInit() {
    this.userName = this.adminService.displayLogin();
      this.adminService.getUsers().subscribe((data: User[]) => {
      this.uarray = data;
    });
  }
}
