import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthService {
     
    constructor(private httpClient: HttpClient) { }
      
    //login(email:string, password:string ): Observable < User > {
        //return this.httpClient.post<User>('/api/Token/Authenticate', {email, password});
    //}          

    logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
    }

    public isLoggedIn() {
        return !this.getExpiration();
    }

    isLoggedOut() {
        return !this.isLoggedIn();
    }

    getExpiration() {
        
        const expiration = localStorage.getItem("token_Id");

        if(expiration != null)
        {
            const expiry = (JSON.parse(atob(expiration.split('.')[1]))).exp;
            return (Math.floor((new Date).getTime() / 1000)) >= expiry;
        }
        return;
    }

    public getRole(){
        const token = localStorage.getItem("token_Id");
        if(token != null)
        {
            let jwtData = token.split('.')[1];
            let decoded = window.atob(jwtData);
            let decodedData = JSON.parse(decoded);

            let isAdmin = decodedData.admin
            console.log(token);
            //console.log(jwtData);
            //console.log(decoded);
            //console.log(decodedData);
            //console.log(isAdmin);
        }
        return;
    }
}