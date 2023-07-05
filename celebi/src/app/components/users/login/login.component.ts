import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from '../admin/admin.service';
import { AuthService } from '../auth/auth.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

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
    message = "";

  ngOnInit(): void {
    this.userName = this.adminService.displayLogin();
  }
  submit(): void {
    if(this.form.controls['userName'].value == "")
    {
      this.message = "Username is empty";
    }
    else if(this.form.controls['password'].value == "")
    {
      this.message = "Password is empty";
    }
    else
    {
      this.http.post(this.apiURL, this.form.getRawValue(),{responseType:'text'}).pipe(catchError(x => this.errorHandler(
        x.status)))
      .subscribe( res => 
        {
          this.authService.login(res, this.form.controls['userName'].value);
        },() => this.router.navigate(['/login']));
    }
  }

  errorHandler(error: {error: { message: string; }; status: any;message: any; }) 
  {
    console.log(error);
    let errorMessage = '';
    if(error.toString() == "400")
    {
      this.message = "You cannot log in using this combination of username and password";
    }
    return throwError(errorMessage);
}
}
