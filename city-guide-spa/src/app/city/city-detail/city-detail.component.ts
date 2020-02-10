import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router"
import { CityService } from 'src/app/services/City.service';
import { City } from 'src/app/models/City';
import { Photo } from 'src/app/models/Photo';

@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.css'],
  providers:[CityService]
})
export class CityDetailComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute, private cityService:CityService) { }

  city:City;
  photos:Photo[]=[];

  ngOnInit() {
    this.activatedRoute.params.subscribe(params=>{
      //route.ts'in içinde tanımladığımız cityId parametresine ulaşıyoruz.
      //direkt ngOnInit'in içinde service'e erişmektense başka bir method oluşturup onun içinde erişiyoruz.
      this.getCityById(params["cityId"])

      this.getPhotosByCity(params["cityId"])
    })
  }
  getCityById(cityId:number) {
    this.cityService.getCityById(cityId).subscribe(data=>{
      this.city=data;
    })
  }

  getPhotosByCity(cityId:number){
    this.cityService.getPhotosByCity(cityId).subscribe(data=>{
      this.photos=data;
    })
  }

}
