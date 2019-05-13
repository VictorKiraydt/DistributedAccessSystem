import { Component } from '@angular/core';

import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: `
    <app-header *ngIf="isUserAuthenticated()"></app-header>
    <router-outlet></router-outlet>
    <app-footer *ngIf="isUserAuthenticated()"></app-footer>`,
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
