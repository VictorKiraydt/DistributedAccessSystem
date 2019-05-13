import { Component, OnInit } from '@angular/core';

import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private jwtHelper: JwtHelper, private router: Router) { }

  ngOnInit() {
  }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  logOut() {
    localStorage.removeItem("jwt");
    this.router.navigate(["/login"]);
  }
}
