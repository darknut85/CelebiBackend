import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from 'src/app/objects/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: FormGroup = this.formBuilder.group({
    userName: ['',Validators.required],
    password: ['',Validators.required]
  });

  private apiURL = "https://localhost:7282/api/Token/Authenticate";
  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router) { }

  submit(): void {
    this.http.post(this.apiURL, this.form.getRawValue(),{responseType:'text'})
      .subscribe( res => 
        {
          console.log(res); 
          localStorage.setItem("token_Id",res)

        },() => this.router.navigate(['/home']));
  }
}
