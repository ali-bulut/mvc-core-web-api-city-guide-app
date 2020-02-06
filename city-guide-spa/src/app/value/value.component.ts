import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Value } from '../models/Value';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  constructor(private http:HttpClient) { }

  values:Value[]=[];


  ngOnInit() {
    //data -> getValues() function'ının return olarak geri döndürdüğü Value dizisi tipindeki gelen datadır.
this.getValues().subscribe(data=>{
  //apiden gelen datayı values'e eşitledik.
  this.values=data;
});
  }

  getValues(){
    //oluşturduğumuz apiden gelen datayı çeker ve tipini Value dizisi tipi şeklinde kaydeder.
    return this.http.get<Value[]>("https://localhost:44332/Api/Values");
  }

}
