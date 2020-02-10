import { Component, OnInit, NgModule } from '@angular/core';
import { CityService } from 'src/app/services/City.service';
import {FormGroup,FormControl,Validators,FormBuilder,ReactiveFormsModule} from '@angular/forms'
import { City } from 'src/app/models/City';


@Component({
  selector: 'app-city-add',
  templateUrl: './city-add.component.html',
  styleUrls: ['./city-add.component.css'],
  providers:[CityService]
})
export class CityAddComponent implements OnInit {

  constructor(private cityService:CityService, private formBuilder:FormBuilder) { }

  city:City;
  //validationları buranın üstünden yapıyoruz.
  cityAddForm:FormGroup;

  createCityForm(){
    this.cityAddForm=this.formBuilder.group(
      //city classındaki 2 değişkenin validationlarını belirledik.
      {name:["",Validators.required],
      description:["",Validators.required]}
    )
  }

  ngOnInit() {
    this.createCityForm();
  }

  add(){
    if(this.cityAddForm.valid){
      //cityAddForm'un valuesini oku onu {} boş objeye ata. O oluşturduğun objeyi de city'ye eşitle.
      this.city=Object.assign({},this.cityAddForm.value)
      //Todo
      this.city.userId=1;
      this.cityService.add(this.city);
    }
  }

}
