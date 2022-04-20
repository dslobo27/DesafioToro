import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/Usuario.model';
import { HeaderCompose } from './header-compose';
import { Result } from '../models/Result.model';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  public url: string = 'http://localhost:6846/api';

  constructor(private httpClient: HttpClient) {}

  obterPorId(usuarioId?: string): Observable<Result> {
    return this.httpClient.get<Result>(`${this.url}/users?usuarioId=${usuarioId}`, {
      headers: HeaderCompose.compose(),
    });
  }
}
