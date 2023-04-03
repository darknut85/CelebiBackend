import { Component } from '@angular/core';
import { AdminService } from '../admin/admin.service';
import { User } from 'src/app/objects/user';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
  constructor(private adminService: AdminService, private route: ActivatedRoute) { }

  user: User = 
  {
    userName: "",
    email: "",
    password: "",
    role: ""
  };
  ngOnInit()
  {
    this.route.paramMap.subscribe((params) =>
    { 
      const id = params.get('id');
      this.adminService.getUserByID(String(id)).subscribe((data: User) => { this.user = data; });
    });
  }
}
