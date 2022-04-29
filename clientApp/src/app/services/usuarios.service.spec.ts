import { TestBed } from '@angular/core/testing';
import { UsuariosService } from './usuarios.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

describe('UsuariosService', () => {
  let service: UsuariosService;
  let httpClient: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });    
    service = TestBed.inject(UsuariosService);
    httpClient = TestBed.inject(HttpClient);
  });

  it('should call get', () => {
    const spy = spyOn(httpClient, 'get').and.callThrough();
    service.obterPorId();
    expect(spy).toHaveBeenCalled();
  });
});
