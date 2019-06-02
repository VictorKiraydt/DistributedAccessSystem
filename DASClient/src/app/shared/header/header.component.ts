import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  logOut() {
    localStorage.removeItem("jwt");
    this.router.navigate(["/login"]);
  }

  toggleSidebar() {
    let sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('active');
    sidebar.style.transition = "1s";
  }

}
