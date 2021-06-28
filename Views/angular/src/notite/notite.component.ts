import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';
import { Notita } from '../services/planifiqator.service';

@Component({
  selector: 'app-notite',
  templateUrl: './notite.component.html',
  styleUrls: ['./notite.component.css']
})
export class NotiteComponent implements OnInit {

  ngOnInit(): void {
    this.getAllNotite()
  }
  toNotitaInitializer: string = "/notite";

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  Nume: any;
  Continut: any;
  UtilizatorId: any = localStorage["Id"]
  Notite: any = []
  Monede: any = localStorage["Monede"]
  getMonede() {
    this.Monede = localStorage["Monede"]
  }
  addNotita() {
    console.log(this.Nume, this.Continut)
    if (this.Nume == null || this.Nume.length < 6 || this.Continut.length<50 || localStorage["Token"] == null){
      this.toastr.error('Completati toate campurile. Asigurati-va ca aveti minim 10 caractere la nume si 50 de caractere la continut', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.AddNotita(this.UtilizatorId, this.Nume, this.Continut).then(data => {
        if (data != null) {
          this.toastr.success('Notita inserata cu succes', 'Success', {
            enableHtml: false,
            closeButton: true,
            timeOut: 5000,
            positionClass: 'toast-top-right'
          });
          this.putMonede(localStorage["Id"],2)
          console.log(data["utilizatorId"])
          console.log(data["nume"])
          console.log(data["continut"])
          this.Nume = ""
          this.Continut = ""
          this.getAllNotite();
        }
      });
    }
  }
  getAllNotite() {
    this.Notite = []
    console.log(this.UtilizatorId)
    if (localStorage["Token"] == null) {
      this.toastr.error('Completati toate campurile.', 'Campuri lipsa', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetAllNotite(this.UtilizatorId).then(data => {
        if (data != null) {
          for (let entry of data) {
            var notita: Notita = new Notita();
            notita.Nume = entry["nume"];
            notita.Continut = entry["continut"];
            this.Notite.push(notita);
          }
          console.log(this.Notite);
        }
      });
    }
  }
  putMonede(UtilizatorId: any
    , RecompensaId: any) {
    if (localStorage["Token"] == null) {
      this.toastr.error('Utilizatorul nu este valid', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.PutMonede(UtilizatorId, RecompensaId).then(data => {
        if (data != null) {
          localStorage.setItem("Monede",data)
          console.log(data);
        }
      });
    }
  }
}
