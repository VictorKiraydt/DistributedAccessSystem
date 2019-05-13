import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
//import { Observable } from 'rxjs';
import { JwtHelper } from 'angular2-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor (private jwtHelper: JwtHelper, private router: Router) {
  }

  canActivate() {
    let token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){
      console.log(this.jwtHelper.decodeToken(token));
      return true;
    }

    this.router.navigate(["login"]);
    return false;
  }
}
