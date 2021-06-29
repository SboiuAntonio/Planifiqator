import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';
import { Utilizator } from '../services/planifiqator.service';

@Component({
  selector: 'app-clasament',
  templateUrl: './clasament.component.html',
  styleUrls: ['./clasament.component.css']
})
export class ClasamentComponent implements OnInit {

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  Users: any = []

  toClasament = "/clasament"

  Monede: any = localStorage["Monede"]

  ngOnInit(): void {
  }
  emptyStorage() {
    localStorage.clear()
  }
  getMonede() {
    this.Monede = localStorage["Monede"]
  }
  getAllUsers() {
    if (localStorage["Token"] == null) {
      this.toastr.error('Utilizatorul nu este valid', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 1000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetAll().then(data => {
        this.Users=[]
        console.log(data)
        if (data != null) {
          console.log(data)
          for (let entry of data) {
            var utilizator: Utilizator = new Utilizator();
            utilizator.Nume = entry["nume"];
            utilizator.Monede = entry["monede"];
            this.Users.push(utilizator);
          }
          console.log(this.Users)
        }
      });
    }
  }
}
