import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
//[formGroup] attribute'ünü kullanmak için bunu eklememiz gerekir
import {ReactiveFormsModule,FormsModule} from '@angular/forms';
import {NgxEditorModule} from 'ngx-editor';
import {FileUploadModule} from 'ng2-file-upload';

import { AppComponent } from "./app.component";
import { ValueComponent } from "./value/value.component";
import { NavComponent } from "./nav/nav.component";
import { CityComponent } from "./city/city.component";
import { RouterModule } from "@angular/router";
import { appRoutes } from "./routes";
import { CityDetailComponent } from "./city/city-detail/city-detail.component";
import { CityAddComponent } from './city/city-add/city-add.component';
import {AlertifyService} from './services/alertify.service'
import { RegisterComponent } from './register/register.component';
import { PhotoComponent } from './photo/photo.component';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      CityComponent,
      CityDetailComponent,
      CityAddComponent,
      RegisterComponent,
      PhotoComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      NgxEditorModule,
      FileUploadModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
