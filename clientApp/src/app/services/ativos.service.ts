import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HeaderCompose } from './header-compose';
import { Result } from '../models/Result.model';
import { ComprarAtivo } from '../models/ComprarAtivo.model';

@Injectable({
  providedIn: 'root',
})
export class AtivosService {
  public url: string = 'http://localhost:6846/api';

  constructor(private httpClient: HttpClient) {}

  obterCincoAtivosMaisVendidos(): Observable<Result> {
    return this.httpClient.get<Result>(`${this.url}/assets/trends`, {
      headers: HeaderCompose.compose(),
    }); 
  }

  finalizarCompra(model: ComprarAtivo): Observable<Result> {
    return this.httpClient.post<Result>(`${this.url}/assets/order`, model, {
      headers: HeaderCompose.compose(),
    }); 
  }
}
