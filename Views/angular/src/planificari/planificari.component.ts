import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from '../services/data.service';
import { Planificare } from '../services/planifiqator.service';

@Component({
  selector: 'app-planificari',
  templateUrl: './planificari.component.html',
  styleUrls: ['./planificari.component.css']
})
export class PlanificariComponent implements OnInit {

  constructor(private dataService: DataService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  toPlanificari = "/planificari"
  Planificari: any = []
  Monede: any = localStorage["Monede"]
  getPlan(){
    var Id: any = localStorage["Id"];
    this.getPlanificari(Id)
  }
  emptyStorage() {
    localStorage.clear()
  }
  getMonede() {
    this.Monede = localStorage["Monede"]
  }
  getPlanificari(Id: any) {
    if (localStorage["Token"] == null) {
      this.toastr.error('Utilizatorul nu este valid', 'Eroare', {
        enableHtml: false,
        closeButton: true,
        timeOut: 5000,
        positionClass: 'toast-top-right'
      });
    }
    else {
      this.dataService.GetPlanificari(Id).then(data => {
        console.log(data)
        if (data != null) {
          for (let entry of data) {
            var planificare: Planificare = new Planificare();
            planificare.Id = entry["id"];
            planificare.DestinatieId = entry["destinatieId"];
            planificare.Data = entry["dataRezervare"];
            this.Planificari.push(planificare);
          }
        }
      });
    }
  }
}
