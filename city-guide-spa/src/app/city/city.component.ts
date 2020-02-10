import { Component, OnInit } from '@angular/core';
import { City } from '../models/City';
import { CityService } from '../services/City.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
  providers:[CityService]
})
export class CityComponent implements OnInit {

  constructor(private cityService:CityService) { }
  cities:City[]
  ngOnInit() {
    this.cityService.getCities().subscribe(data=>{
      this.cities=data;
    })
  }

}
