import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Nume: any;
  Parola: any;
  x: any;
  toHomeInitializer: string = "/login";

  displayedColumns: string[] = ['Nume', 'Continut'];

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {

  }
  login() {
    if (this.Nume == null || this.Parola == null) {
      this.toastr.error('Completati toate campurile.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.Login(this.Nume, this.Parola).then(data =>   {
        if (data != null) {
          console.log(this.Nume, this.Parola);
          this.toastr.success('Conectarea s-a făcut cu succes!', 'Success', {
            enableHtml: false,
            closeButton: true,
            timeOut: 5000,
            positionClass: 'toast-top-right'
          });
          console.log(data["id"])
          console.log(data["nume"])
          console.log(data["email"])
          console.log(data["parola"])
          console.log(data["monede"])
          console.log(data["token"])
          localStorage.clear();
          localStorage.setItem("Id", data["id"])
          localStorage.setItem("Nume", data["nume"])
          localStorage.setItem("Email", data["email"])
          localStorage.setItem("Parola", data["parola"])
          localStorage.setItem("Monede", data["monede"])
          localStorage.setItem("Token", data["token"])
          console.log(localStorage)
          this.x = data["id"]
          this.afis();
          this.router.navigate(['cauta-destinatii']);
        }
      });
    }
  }
  afis() {
    console.log(this.x)
  }
}
