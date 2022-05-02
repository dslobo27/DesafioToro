import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public url: string = environment.api_url;

  constructor(private httpClient: HttpClient) { }  

  autenticar(model: any) {
    return this.httpClient.post(`${this.url}/login`, model);
  }
}
