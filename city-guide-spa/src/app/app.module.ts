import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';

@NgModule({
   //eklemek istediğimiz componentleri burada projeye ekliyoruz.
   declarations: [
      AppComponent,
      ValueComponent
   ],
   //eklemek istediğimiz kütüphaneleri burada projeye ekliyoruz.
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
