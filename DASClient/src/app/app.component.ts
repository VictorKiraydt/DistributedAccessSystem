import { Component } from '@angular/core';

import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: `
    <router-outlet *ngIf="!isUserAuthenticated()"></router-outlet>
    
    <div class="wrapper" *ngIf="isUserAuthenticated()">
      <app-header></app-header>
      <app-nav></app-nav>
      <div class="content">
        <router-outlet></router-outlet>
      </div>
    </div>`,
  styles: []
})
export class AppComponent {
  
  constructor (private jwtHelper: JwtHelper, private router: Router) { }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }
}
