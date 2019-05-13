import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './shared/header/header.component';
import { NavComponent } from './shared/nav/nav.component';
import { FooterComponent } from './shared/footer/footer.component';

import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CustomersComponent } from './pages/customers/customers.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    CustomersComponent
],
imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(router: Router) { }
}
