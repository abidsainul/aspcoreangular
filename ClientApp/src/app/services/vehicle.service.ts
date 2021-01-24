import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import 'rxjs/add/operator/map';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes(){
    return this.http.request('GET', '/api/makes', {responseType:'json'});
  }

  getFeatures(){
    return this.http.request('GET', '/api/features', {responseType:'json'});
  }
}
