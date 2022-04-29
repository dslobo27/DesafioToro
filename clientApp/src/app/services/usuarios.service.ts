import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HeaderCompose } from './header-compose';
import { Result } from '../models/Result.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  public url: string = environment.api_url;

  constructor(private httpClient: HttpClient) {}

  obterPorId(usuarioId?: string): Observable<Result> {
    return this.httpClient.get<Result>(
      `${this.url}/users?usuarioId=${usuarioId}`,
      {
        headers: HeaderCompose.compose(),
      }
    );
  }
}
