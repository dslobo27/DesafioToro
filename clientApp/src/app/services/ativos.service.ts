import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ativo } from '../models/Ativo.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AtivosService {
  constructor(private httpClient: HttpClient) {}

  obterCincoAtivosMaisVendidos(): Observable<Array<Ativo>> {
    return this.httpClient.get<Array<Ativo>>('http://localhost:6846/api/assets/trends');
  }
}
