import { CityComponent } from "./city/city.component";
import { ValueComponent } from "./value/value.component";
import { Routes } from "@angular/router";
import { CityDetailComponent } from './city/city-detail/city-detail.component';

export const appRoutes: Routes = [
  { path: "city", component: CityComponent },
  { path: "value", component: ValueComponent },
  //route'un içinde cityId parametresi aldık.
  { path: "cityDetail/:cityId", component: CityDetailComponent },
  //city yada value dışında bir path gelirse city route'una yönlendir.
  //city ve value'yi **'dan ayıran kısım ise pathMatch kısmıdır. Çünkü ** tüm routeları kapsar
  //ama pathMatch full vererek tanımladıklarımızı buradan çıkardık.
  { path: "**", redirectTo: "city", pathMatch: "full" }
];
