import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from "../models/City";
import { Photo } from '../models/Photo';
import { AlertifyService } from './alertify.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: "root"
})
export class CityService {
  constructor(private httpClient: HttpClient, private alertifyService:AlertifyService, private router:Router) {}

  path = "https://localhost:44332/Api/";

  getCities(): Observable<City[]> {
    return this.httpClient.get<City[]>(this.path + "Cities");
  }

  getCityById(cityId:number):Observable<City>{
    return this.httpClient.get<City>(this.path+"cities/detail/"+cityId);
  }

  getPhotosByCity(cityId:number):Observable<Photo[]>{
    return this.httpClient.get<Photo[]>(this.path+"cities/photos/"+cityId);
  }

  add(city){
    this.httpClient.post(this.path+"cities/add",city).subscribe(data=>{
      this.alertifyService.success("City was added successfully!");
      this.router.navigateByUrl("/cityDetail/"+data["id"])
    });   

  }
}
