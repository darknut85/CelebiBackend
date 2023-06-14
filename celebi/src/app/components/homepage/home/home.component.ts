import { Component } from '@angular/core';
import { AdminService } from '../../users/admin/admin.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private adminService: AdminService){}
  userName = "";
  ngOnInit(): void {
    this.userName = this.adminService.displayLogin();
  }
}
