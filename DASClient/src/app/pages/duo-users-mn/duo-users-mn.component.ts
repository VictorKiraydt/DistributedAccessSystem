import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient, HttpHeaders, HttpHandler, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-duo-users-mn',
  templateUrl: './duo-users-mn.component.html',
  styleUrls: ['./duo-users-mn.component.css']
})
export class DuoUsersMnComponent implements OnInit {

  duoUser: any;

  @ViewChild('inptSearchEmail') inptSearchEmail: ElementRef;
  @ViewChild('btnFindUser')     btnFindUser: ElementRef;
  @ViewChild('btnResetPhones')  btnResetPhones: ElementRef;
  @ViewChild('messageBody')     messageBody: ElementRef;
  @ViewChild('tfaResetInfo')    tfaResetInfo: ElementRef;
  
  //@ViewChild('popupFoundUser')  popupFoundUser: ElementRef;
  //@ViewChild('popupMessage')    popupMessage: ElementRef;
  @ViewChild('inptFirstName')   inptFirstName: ElementRef;
  @ViewChild('inptLastName')    inptLastName: ElementRef;
  @ViewChild('inptUserName')    inptUserName: ElementRef;
  @ViewChild('inptOutputEmail') inptOutputEmail: ElementRef;
  @ViewChild('inptUserPhone')   inptUserPhone: ElementRef;
  @ViewChild('inptIsEnrolled')  inptIsEnrolled: ElementRef;
  @ViewChild('inptStatus')      inptStatus: ElementRef;
  @ViewChild('inptLastLogin')   inptLastLogin: ElementRef;
  
  @ViewChild('btnClosePopupFoundUser')    btnClosePopupFoundUser: ElementRef;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  findUser() {
    this.clearModalWindowFields();
    this.tfaResetInfo.nativeElement.innerHTML = "";

    let email = this.inptSearchEmail.nativeElement.value as string;
    let token = localStorage.getItem("jwt");

    let getOptions = {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Type": "application/json",
        "userEmail": email
      })
    };

    this.http.get("https://localhost:5000/api/duo/find-user", getOptions)
    .subscribe(response => {
      this.duoUser = response['duoUser'] as [string, any];

      if (this.duoUser['firstname'] as string === null) {
        this.inptFirstName.nativeElement.parentElement.style.display = "none";
      }
      else {
        this.inptFirstName.nativeElement.value = this.duoUser['firstname'] as string;
      }
      if (this.duoUser['lastname'] as string === null) {
        this.inptLastName.nativeElement.parentElement.style.display = "none";
      }
      else {
        this.inptLastName.nativeElement.value = this.duoUser['lastname'] as string;
      }

      this.inptUserName.nativeElement.value = this.duoUser['username'] as string;
      this.inptOutputEmail.nativeElement.value = this.duoUser['email'] as string;
      this.inptIsEnrolled.nativeElement.checked = this.duoUser['is_enrolled'] as boolean;
      this.inptStatus.nativeElement.value = this.duoUser['status'] as string;
      this.inptLastLogin.nativeElement.value = new Date(
        this.duoUser['last_login'] as number * 1000).toUTCString();
      
      if (this.duoUser['phones'].length > 0) {
        this.btnResetPhones.nativeElement.style.display = "block";

        (this.duoUser['phones']).forEach((phone: [string, any]) => {
          this.inptUserPhone.nativeElement.value = phone['number'] as string + "; ";
        });
      }

      this.btnFindUser.nativeElement.setAttribute("data-target", "#popupFoundUser");
      this.btnFindUser.nativeElement.click();
    }, err => {
      this.messageBody.nativeElement.innerHTML = "The user <b>" + email + "</b> couldn't be found!";
      console.log(err);
      
      this.btnFindUser.nativeElement.setAttribute("data-target", "#popupMessage");
      this.btnFindUser.nativeElement.click();
    });
  }

  resetPhones() {
    if (this.duoUser !== null) {
      console.log(this.duoUser);
      let email = this.inptSearchEmail.nativeElement.value;
      let token = localStorage.getItem("jwt");

      let deleteOptions = {
        headers: new HttpHeaders({
          "Authorization": "Bearer " + token,
          "Content-Type": "application/json"
        }),
        body: this.duoUser['phones'] as Array<[string, object]>
      };
      this.http.delete("https://localhost:5000/api/duo/tfa-reset", deleteOptions)
      .subscribe(response => {
        let messageObj = response as [string, any];
        this.tfaResetInfo.nativeElement.innerHTML = messageObj['message'];
        
        this.btnClosePopupFoundUser.nativeElement.click();
      }, err => {
        console.log(err);
        this.tfaResetInfo.nativeElement.innerHTML = "The user's phone(s) have NOT been deleted successfully.";
        
        this.btnClosePopupFoundUser.nativeElement.click();
      });
    }
  }

  onKeyUp($event: any) {
    if (this.inptSearchEmail.nativeElement.value.trim() !== "") {
      this.btnFindUser.nativeElement.disabled = false;
    }
    else {
      this.btnFindUser.nativeElement.disabled = true;
    }

    if (this.inptSearchEmail.nativeElement.value.trim() !== ""
    &&  $event.keyCode === 13) {
      this.findUser();
    }
  }

  clearModalWindowFields() {
    this.inptFirstName.nativeElement.value =
    this.inptLastName.nativeElement.value =
    this.inptUserName.nativeElement.value =
    this.inptOutputEmail.nativeElement.value =
    this.inptStatus.nativeElement.value =
    this.inptLastLogin.nativeElement.value =
    this.inptUserPhone.nativeElement.value =
    this.messageBody.nativeElement.innerHTML = "";
    this.inptIsEnrolled.nativeElement.checked = false;
    this.btnResetPhones.nativeElement.style.display = "none";
  }

}
