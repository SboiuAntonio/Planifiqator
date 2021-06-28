import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';
import { UtilizatorNume } from '../services/planifiqator.service';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {


  ngOnInit(): void {
    this.getMonede()
  }

  toProfilInitializer: string = "/profil";

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  Nume: any;
  Email: any;
  Parola: any;
  Id: any = localStorage["Id"]
  Monede: any
  getMonede() {
    this.Monede = localStorage["Monede"]
    console.log(localStorage)
  }
  putNume() {
    console.log(this.Nume)
    if (this.Nume == null || localStorage["Token"]==null) {
      this.toastr.error('Completati campul nume.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.PutNume(this.Id, this.Nume).then(data => {
        if (data != null) {
          this.toastr.success('Numele s-a updatat cu succes', 'Success', {
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
          localStorage.setItem("Nume", data["nume"])
          console.log(localStorage);
          this.Nume = ""
        }
      });
    }
  }
  putEmail() {
    console.log(this.Email)
    if (this.Email == null || localStorage["Token"] == null) {
      this.toastr.error('Completati campul email.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 1000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.PutEmail(this.Id, this.Email).then(data => {
        if (data != null) {
          this.toastr.success('Emailul s-a updatat cu succes', 'Success', {
            enableHtml: false,
            closeButton: true,
            timeOut: 1000,
            positionClass: 'toast-top-right'
          });
          console.log(data["id"])
          console.log(data["nume"])
          console.log(data["email"])
          console.log(data["parola"])
          console.log(data["monede"])
          console.log(data["token"])
          localStorage.setItem("Email", data["email"])
          console.log(localStorage);
          this.Email = ""
        }
      });
    }
  }
  putParola() {
    console.log(this.Parola)
    if (this.Parola == null || localStorage["Token"] == null) {
      this.toastr.error('Completati campul parola.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 1000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.PutParola(this.Id, this.Parola).then(data => {
        if (data != null) {
          this.toastr.success('Parola s-a updatat cu succes', 'Success', {
            enableHtml: false,
            closeButton: true,
            timeOut: 1000,
            positionClass: 'toast-top-right'
          });
          console.log(data["id"])
          console.log(data["nume"])
          console.log(data["email"])
          console.log(data["parola"])
          console.log(data["monede"])
          console.log(data["token"])
          localStorage.setItem("Parola", data["Parola"])
          console.log(localStorage);
          this.Parola = ""
        }
      });
    }
  }
}
