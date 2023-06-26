import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin/admin.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private adminService: AdminService){}

  userName = "";

  ngOnInit()
  {
    this.userName = this.adminService.displayLogin();
  }
}
