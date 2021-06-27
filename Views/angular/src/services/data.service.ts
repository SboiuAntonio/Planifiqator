import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Utilizator} from './planifiqator.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private httpClient: HttpClient) {
  }
  Register(user: Utilizator): Observable<HttpRequest<any>> {
    let url = "http://localhost:5000/app/Register";
    let payload = { data: user };
    return this.httpClient.post<any>(url, payload.data, { responseType: 'json' as 'json' });
  }

  GetNume(Nume: any): Observable<HttpResponse<any>> {
    let url = "http://localhost:5000/app/Register/GetNume";
    let payload = { "Nume": Nume };
    return this.httpClient.post<any>(url, payload, { responseType: 'json' as 'json' });
  }

  GetEmail(Email: any): Observable<HttpResponse<any>> {
    let url = "http://localhost:5000/app/Register/GetEmail";
    let payload = { "Email": Email };
    return this.httpClient.post<any>(url, payload, { responseType: 'json' as 'json' });
  }

  Login(Nume: any, Parola: any): Promise<any> {
    let url = "http://localhost:5000/app/Login";
    let body = { "Nume": Nume, "Parola": Parola };
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  PutNume(Id: any, Nume: any): Promise<any> {
 
    let url = "http://localhost:5000/app/Profil/nume";
    var body = {"Id": Id, "Nume": Nume};
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  PutEmail(Id: any, Email: any): Promise<any> {

    let url = "http://localhost:5000/app/Profil/email";
    var body = { "Id": Id, "Email": Email };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  PutParola(Id: any, Parola: any): Promise<any> {

    let url = "http://localhost:5000/app/Profil/parola";
    var body = { "Id": Id, "Parola": Parola };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  AddNotita(UtilizatorId: any, Nume: any, Continut: any): Promise<any> {

    let url = "http://localhost:5000/app/Notite/insert";
    var body = { "UtilizatorId": UtilizatorId, "Nume": Nume, "Continut": Continut };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetAllNotite(UtilizatorId: any): Promise<any> {

    let url = "http://localhost:5000/app/Notite/getAll";
    var body = { "UtilizatorId": UtilizatorId};
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetAllDestinatii(): Promise<any> {

    let url = "http://localhost:5000/app/CautaDestinatii/all";
    return this.httpClient.post<any>(url, { responseType: 'json' as 'json' }).toPromise();
  }
  GetDestinatieByTara(Tara: string): Promise<any> {

    let url = "http://localhost:5000/app/CautaDestinatii/tara";
    var body = { "Tara": Tara };
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetDestinatieByRegiune(Regiune: string): Promise<any> {

    let url = "http://localhost:5000/app/CautaDestinatii/regiune";
    var body = { "Regiune": Regiune };
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetDestinatieByOras(Oras: string): Promise<any> {

    let url = "http://localhost:5000/app/CautaDestinatii/oras";
    var body = { "Oras": Oras };
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  PutRating(Id: any, NumarRatinguri: any, Rating: any): Promise<any> {

    let url = "http://localhost:5000/app/CautaDestinatii/rating";
    var body = { "Id": Id, "NumarRatinguri": NumarRatinguri, "Rating": Rating };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  PutMonede(UtilizatorId: any, RecompensaId: any): Promise<any> {

    let url = "http://localhost:5000/app/UtilizatorRecompensat/addMonede";
    var body = { "UtilizatorId": UtilizatorId, "RecompensaId": RecompensaId };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  AddRezervare(UtilizatorId: any, DestinatieId: any, Data: any): Promise<any> {

    let url = "http://localhost:5000/app/profil/addRezervareVacanta";
    var body = { "UtilizatorId": UtilizatorId, "DestinatieId": DestinatieId, "DataRezervare":Data };
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetPlanificari(UtilizatorId: any): Promise<any> {

    let url = "http://localhost:5000/app/profil/GetPlanificare";
    var body = { "UtilizatorId": UtilizatorId};
    console.log(body);
    return this.httpClient.post<any>(url, body, { responseType: 'json' as 'json' }).toPromise();
  }
  GetAll(): Promise<any> {

    let url = "http://localhost:5000/app/profil/getAll";
    return this.httpClient.post<any>(url, { responseType: 'json' as 'json' }).toPromise();
  }
}
