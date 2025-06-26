import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import api from '../apiUrl/api.json';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MateriaService {
  private _http= inject(HttpClient);


  getMaterias():Observable<any> {
    return this._http.get(api.apiUrl+api.getMateriasUrl); 
  }
}
