import { Injectable } from "@angular/core";
import { LoginUser } from "../models/LoginUser";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { JwtHelper, tokenNotExpired } from "angular2-jwt";
import { Router } from "@angular/router";
import { AlertifyService } from "./alertify.service";
import { RegisterUser } from "../models/RegisterUser";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  path = "https://localhost:44332/Api/Auth/";
  userToken: any;
  decodedToken: any;

  jwtHelper: JwtHelper = new JwtHelper();

  TOKEN_KEY="token";

  login(loginUser: LoginUser) {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    //headers değeri için headers'ı yolla.
    this.httpClient
      .post(this.path + "login", loginUser, { headers: headers })
      .subscribe((data)=> {
        //data olarak direkt string değerindeki token geliyor.
        this.saveToken(data);
        this.userToken = data;
        this.decodedToken = this.jwtHelper.decodeToken(data.toString());
        this.alertify.success("Login succeed!");
        
        this.router.navigateByUrl("/city");
      },(error)=>{this.alertify.error("Login failed!")});
  }

  register(registerUser: RegisterUser) {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    this.httpClient.post(this.path+"register",registerUser,{headers:headers}).subscribe(data=>{
      this.alertify.success("Registration is successful! Please log in to continue.");
      this.router.navigateByUrl("/city");
    });
  }

  saveToken(token) {
    //token'ı localStorage'a kaydet.
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertify.error("Logged Out!");
  }

  loggedIn(){
    //token varsa ama süresi geçmişse login gerektiren sayfalara giremez.
    return tokenNotExpired(this.TOKEN_KEY);
  }

  get token(){
    return localStorage.getItem(this.TOKEN_KEY)
  }

  getCurrentUserId(){
    return this.jwtHelper.decodeToken(this.token).nameid
  }

  

}
