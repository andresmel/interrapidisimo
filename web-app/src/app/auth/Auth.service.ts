import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import  api from '../apiUrl/api.json';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _httpclien:HttpClient) {}

  postLogin(data: any): Observable<any> {
    console.log(api.apiUrl+api.loginUrl);
    return this._httpclien.post(api.apiUrl+api.loginUrl,data);
  }

  postEstudiante(data: any): Observable<any> {
    return this._httpclien.post(api.apiUrl+api.registerUrl,data);
  }



}
