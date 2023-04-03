import { Component, Injectable, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/objects/user';
import { AuthService } from '../auth/auth.service';
import { AdminService } from './admin.service';

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

  constructor(private adminService: AdminService, private dialog: MatDialog, private router: Router, private auth: AuthService) { }

  uarray: User[] = [];
  ngOnInit() {
      this.adminService.getUsers().subscribe((data: User[]) => {
      this.uarray = data;
    });
  }
}
