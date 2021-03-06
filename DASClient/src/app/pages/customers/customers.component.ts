import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  
  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    let token = localStorage.getItem("jwt");

    this.http.get("https://localhost:5000/api/customers", {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      this.customers = response;
      console.log(response);
    }, err => {
      console.log(err)
    });
  }

}
