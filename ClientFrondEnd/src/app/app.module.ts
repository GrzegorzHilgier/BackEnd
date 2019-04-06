import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { ClientDetailComponent } from './client-details/client-detail/client-detail.component';
import { ClientDetailListComponent } from './client-details/client-detail-list/client-detail-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientDetailsComponent,
    ClientDetailComponent,
    ClientDetailListComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
