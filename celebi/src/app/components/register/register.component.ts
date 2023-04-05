import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/objects/user';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  userName = "";
  ngOnInit(): void {
    this.userName = this.pokemonService.displayLogin();
  }
    form: FormGroup = this.formBuilder.group({
      userName: ['',Validators.required],
      email: ['', Validators.required],
      password: ['',Validators.required],
      role: ['',Validators.required]
    });
  
    private apiURL = "https://localhost:7282/api/Token/Register";
    httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
  }
  
    constructor(private formBuilder: FormBuilder, private http: HttpClient, 
                private router: Router, private pokemonService: PokemonService) { }
  
    submit(): void {
      this.http.post(this.apiURL, this.form.getRawValue(),{responseType:'text'})
        .subscribe( res => 
          {const user: User = 
            {
              userName: this.form.controls['userName'].value, 
              email: this.form.controls['email'].value,
              password: this.form.controls['password'].value,
              role: this.form.controls['role'].value
            };
            
            const role: string = "User";
            this.addUser(user);
            this.router.navigate(['/home']);
  
          },() => this.router.navigate(['/register']));
  }

  addUser(user: User): Observable < User > {
    return this.http.post < User > (this.apiURL, JSON.stringify(user), this.httpOptions);
  }
}
