import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/auth.guard';
import { JwtHelper } from 'angular2-jwt';

import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CustomersComponent } from './pages/customers/customers.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard] }
];

@NgModule ({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
    providers: [JwtHelper, AuthGuard]
})
export class AppRoutingModule { }