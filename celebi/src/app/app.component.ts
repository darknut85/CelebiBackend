import { Component, OnInit } from '@angular/core';
import { AuthService } from './components/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'celebi';
  loggedIn = "";

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    if(this.authService.isLoggedIn())
    {
      const token = localStorage.getItem("username");
      if(token != null)
      {
        this.loggedIn = token;
      }
    }
  }
}
