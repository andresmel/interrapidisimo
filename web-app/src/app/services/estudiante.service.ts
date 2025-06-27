import { Injectable,inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import api from '../apiUrl/api.json';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  private _http=inject(HttpClient);

  getClases(id:number):Observable<any> {
    return this._http.get<any[]>(api.apiUrl+api.clasesUrl+`?id=${id}`);
  }


  getCLasesEstudiantes(id:number):Observable<any> {
    return this._http.get<any[]>(api.apiUrl+api.getCLasesEstudiantesUrl+`?id=${id}`);
  }

  getEstudiantesByClase(id:number):Observable<any>{
    return this._http.get(api.apiUrl+api.getEstudiantesByClaseUrl+`?id=${id}`)
  }
}
