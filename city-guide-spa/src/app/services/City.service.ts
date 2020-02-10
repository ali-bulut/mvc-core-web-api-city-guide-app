import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from "../models/City";
import { Photo } from '../models/Photo';

@Injectable({
  providedIn: "root"
})
export class CityService {
  constructor(private httpClient: HttpClient) {}
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
}
