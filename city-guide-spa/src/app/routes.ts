import { CityComponent } from "./city/city.component";
import { ValueComponent } from "./value/value.component";
import { Routes } from "@angular/router";
import { CityDetailComponent } from './city/city-detail/city-detail.component';
import { CityAddComponent } from './city/city-add/city-add.component';
import { RegisterComponent } from './register/register.component';

export const appRoutes: Routes = [
  { path: "city", component: CityComponent },
  { path: "value", component: ValueComponent },
  //route'un içinde cityId parametresi aldık.
  { path: "cityDetail/:cityId", component: CityDetailComponent },
  { path: "cityAdd", component: CityAddComponent },
  { path: "register", component: RegisterComponent },
  //city yada value dışında bir path gelirse city route'una yönlendir.
  //city ve value'yi **'dan ayıran kısım ise pathMatch kısmıdır. Çünkü ** tüm routeları kapsar
  //ama pathMatch full vererek tanımladıklarımızı buradan çıkardık.
  { path: "**", redirectTo: "city", pathMatch: "full" }
];
