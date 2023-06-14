import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from '../admin/admin.service';
import { AuthService } from '../auth/auth.service';

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

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router,
    private adminService: AdminService, private authService: AuthService) { }
  userName = "";
  ngOnInit(): void {
    this.userName = this.adminService.displayLogin();
  }
  submit(): void {
    this.http.post(this.apiURL, this.form.getRawValue(),{responseType:'text'})
      .subscribe( res => 
        {
          this.authService.login(res, this.form.controls['userName'].value);
          this.router.navigate(['/home']);

        },() => this.router.navigate(['/login']));
  }
}
