import { Component, OnInit } from '@angular/core';
import { AuthService } from './components/users/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'celebi';
  loggedIn = "";

  turnOn = true;

  constructor(private authService: AuthService) { }
  ngOnInit(): void {
    this.turnOn = this.authService.isLoggedIn();
  }
}
