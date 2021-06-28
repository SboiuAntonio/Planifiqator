import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { ToastrService } from 'ngx-toastr';
import { Utilizator } from '../services/planifiqator.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Nume: any;
  Email: any;
  Parola: any;
  Id: any;

  NumeValid : String ="0"
  EmailValid : String ="0"

  toLoginInitializer: string = "/register";

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register() {
    this.getEmail();
    this.getNume();
    if (this.Nume == null || this.Email == null || this.Parola == null ) {
      this.toastr.error('Completati toate campurile.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
      this.NumeValid = "0";
      this.EmailValid = "0";
    }
    else if (this.Parola.length < 8) {
      this.toastr.error('Parola trebuie sa aiba minim 8 caractere', 'Parola scurta', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
      this.NumeValid = "0";
      this.EmailValid = "0";
    }
    else if (this.NumeValid == "0" || this.EmailValid == "0") {
      this.toastr.error('Datele sunt invalide', 'Date invalide', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
      this.NumeValid = "0";
      this.EmailValid = "0";
    } 
    else {
      let user: Utilizator = new Utilizator();
      user.Nume = this.Nume;
      user.Email = this.Email;
      user.Parola = this.Parola;

      this.dataService.Register(user).subscribe(data => {
        console.log(data);
        console.log(data.body);
        this.toastr.success('Înregistrarea s-a făcut cu succes!', 'Success', {
          enableHtml: false,
          closeButton: true,
          timeOut: 5000,
          positionClass: 'toast-top-right'
        });
      });
      this.NumeValid = "0";
      this.EmailValid = "0";
      this.router.navigate(['login']);
    }
  }
  getEmail() {
      this.dataService.GetEmail(this.Email).subscribe(data => {
        if (data == null) {
          this.EmailValid="DA"
        } 
      });
  }
  getNume() {
    this.dataService.GetNume(this.Nume).subscribe(data => {
      if (data == null) {
        this.NumeValid = "DA"
      }
    });
    }
}

