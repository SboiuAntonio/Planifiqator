import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';
import { Destinatie } from '../services/planifiqator.service';

@Component({
  selector: 'app-cauta-destinatii',
  templateUrl: './cauta-destinatii.component.html',
  styleUrls: ['./cauta-destinatii.component.css']
})
export class CautaDestinatiiComponent implements OnInit {

  ngOnInit(): void {
  }

  toDestinatiiInitializer: string = "/cauta-destinatii";

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  Destinatii: any = []
  Field: any = []
  Rating: any
  Monede: any = localStorage["Monede"]
  IdDest: any

  getMonede() {
    this.Monede = localStorage["Monede"]
  }

  getDestinatii() {
    let optiune = (<HTMLSelectElement>document.getElementById('destinatii')).value;
    if (optiune == "Nu am preferinta") {
      this.getAllDestinatii()
    }
    else if (optiune == "Tara") {
      this.getDestinatiiByTara()
    }
    else if (optiune == "Regiune") {
      this.getDestinatiiByRegiune()
    }
    else if (optiune == "Oras") {
      this.getDestinatiiByOras()
    }
  }
  addRez(idDestinatie: any ) {
    let data = (<HTMLSelectElement>document.getElementById("Data"+idDestinatie)).value;
    console.log(data)
    let idUtilizator = localStorage["Id"]
    this.addRezervare(idUtilizator,idDestinatie,data) 
  }
  getAllDestinatii() {
    this.Destinatii = []
    if (localStorage["Token"] == null || localStorage["Monede"]<15) {
      this.toastr.error('Utilizatorul nu este valid sau nu are suficiente monede', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetAllDestinatii().then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 1);
          this.getMonede();
          for (let entry of data) {
            var destinatie: Destinatie = new Destinatie();
            destinatie.Id = entry["id"];
            destinatie.Tara = entry["tara"];
            destinatie.Regiune = entry["regiune"];
            destinatie.Oras = entry["oras"];
            destinatie.NumeDestinatie = entry["numeDestinatie"];
            destinatie.Rating = entry["rating"];
            destinatie.NumarRatinguri = entry["numarRatinguri"];
            this.Destinatii.push(destinatie);
          }
          console.log(this.Destinatii);
        }
      });
    }
  }
  getDestinatiiByTara() {
    this.Destinatii = []
    if (this.Field == "" || localStorage["Token"] == null) {
      this.toastr.error('Utilizatorul nu este valid sau nu ati introdus tara corecta' , 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetDestinatieByTara(this.Field).then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 1);
          for (let entry of data) {

            var destinatie: Destinatie = new Destinatie();
            destinatie.Id = entry["id"];
            destinatie.Tara = entry["tara"];
            destinatie.Regiune = entry["regiune"];
            destinatie.Oras = entry["oras"];
            destinatie.NumeDestinatie = entry["numeDestinatie"];
            destinatie.Rating = entry["rating"];
            destinatie.NumarRatinguri = entry["numarRatinguri"];
            this.Destinatii.push(destinatie);
          }
          console.log(this.Destinatii);
        }
      });
    }
  }
  getDestinatiiByRegiune() {
    this.Destinatii = []
    if (this.Field == "" || localStorage["Token"] == null || localStorage["Monede"] < 15) {
      this.toastr.error('Utilizatorul nu este valid sau nu ati introdus regiunea corecta', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut:5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetDestinatieByRegiune(this.Field).then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 1);
          for (let entry of data) {
            var destinatie: Destinatie = new Destinatie();
            destinatie.Id = entry["id"];
            destinatie.Tara = entry["tara"];
            destinatie.Regiune = entry["regiune"];
            destinatie.Oras = entry["oras"];
            destinatie.NumeDestinatie = entry["numeDestinatie"];
            destinatie.Rating = entry["rating"];
            destinatie.NumarRatinguri = entry["numarRatinguri"];
            this.Destinatii.push(destinatie);
          }
          console.log(this.Destinatii);
        }
      });
    }
  }
  emptyStorage(){
    localStorage.clear()
  }
  getDestinatiiByOras() {
    this.Destinatii = []
    if (this.Field == "" || localStorage["Token"] == null || localStorage["Monede"] < 15) {
      this.toastr.error('Utilizatorul nu este valid sau orasul nu este corect', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetDestinatieByOras(this.Field).then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 1);
          for (let entry of data) {    
            var destinatie: Destinatie = new Destinatie();
            destinatie.Id = entry["id"];
            destinatie.Tara = entry["tara"];
            destinatie.Regiune = entry["regiune"];
            destinatie.Oras = entry["oras"];
            destinatie.NumeDestinatie = entry["numeDestinatie"];
            destinatie.Rating = Math.round(entry["rating"]*10)/10
            destinatie.NumarRatinguri = entry["numarRatinguri"];
            this.Destinatii.push(destinatie);
          }
          console.log(this.Destinatii);
        }
      });
    }
  }
  putRating(Id: any
    , Count: any) {
    let rating = (<HTMLSelectElement>document.getElementById("ratinguri" +Id)).value;
    if (localStorage["Token"] == null && rating === undefined) {
      this.toastr.error('Utilizatorul nu este valid sau nu s-a introdus un rating', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.PutRating(Id,Count,rating).then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 2)
          this.getDestinatii()
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
      this.dataService.PutMonede(UtilizatorId,RecompensaId).then(data => {
        if (data != null) {
          localStorage.setItem("Monede", data)
        }
      });
    }
  }
  addRezervare(IdUtilizator: any, IdDestinatie: any, Data: any) {
    if (localStorage["Token"] == null || Data === "" || Data === undefined) {
      this.toastr.error('Data nu este valida, nu se poate insera vacanta', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.AddRezervare(IdUtilizator, IdDestinatie, Data).then(data => {
        if (data != null) {
          this.putMonede(localStorage["Id"], 2)
          console.log(data);
        }
      });
    }
  }
}
