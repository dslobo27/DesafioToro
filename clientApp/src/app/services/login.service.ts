import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public url: string = 'http://localhost:6846/api';

  constructor(private httpClient: HttpClient) { }  

  autenticar(model: any) {
    return this.httpClient.post(`${this.url}/login`, model);
  }
}
