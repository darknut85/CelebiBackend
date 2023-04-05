import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PokemonService } from '../pokedexRedBlue/pokedexRedBlue.service';

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

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router, private pokemonService: PokemonService) { }
  userName = "";
  ngOnInit(): void {
    this.userName = this.pokemonService.displayLogin();
  }
  submit(): void {
    this.http.post(this.apiURL, this.form.getRawValue(),{responseType:'text'})
      .subscribe( res => 
        {
          localStorage.setItem("token_Id",res);
          const user = this.form.controls['userName'].value;
          localStorage.setItem("username",user);
          this.router.navigate(['/home']);

        },() => this.router.navigate(['/login']));
  }
}
