import { TestBed } from '@angular/core/testing';
import { AtivosService } from './ativos.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { ComprarAtivo } from '../models/ComprarAtivo.model';

describe('AtivosService', () => {
  let service: AtivosService;
  let httpClient: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });    
    service = TestBed.inject(AtivosService);
    httpClient = TestBed.inject(HttpClient);
  });

  it('should call get', () => {
    const spy = spyOn(httpClient, 'get').and.callThrough();
    service.obterCincoAtivosMaisVendidos();
    expect(spy).toHaveBeenCalled();
  });

  it('should call post', () => {
    const spy = spyOn(httpClient, 'post').and.callThrough();

    let model = new ComprarAtivo();
    model.ativoId = 'fe2225e3-9f83-4da3-911c-a7d3adffb239';
    model.usuarioId = '630f8c24-40b6-4994-853a-625d564b0a60';
    model.quantidadeSolicitada = 1;

    service.finalizarCompra(model);
    
    expect(spy).toHaveBeenCalled();
  });
});
