import { Injectable } from "@angular/core";



export class Utilizator {
  Id!: number;
  Nume!: string;
  Parola!: string;
  Email!: string;
  Monede!: string;
}

export class Destinatie {
  Id!: string;
  Tara! :string;
  Regiune!: string;
  Oras!: string;
  NumeDestinatie!: string;
  Rating!: number;
  NumarRatinguri!: string;
}

export class Planificare {
  Id!: number;
  DestinatieId!: number;
  Data!: string
}



export class Notita {
  Nume!: string;
  Continut!: string;
}

export class UtilizatorNume {
  Nume!: string;
}
@Injectable({
  providedIn: 'root'
})
export class PlanifiqatorService {

  constructor() { }
}
