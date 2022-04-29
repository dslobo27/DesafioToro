import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';
import { LoadingComponent } from 'src/app/components/loading/loading.component';
import { Ativo } from 'src/app/models/Ativo.model';
import { ContaCorrente } from 'src/app/models/ContaCorrente.model';
import { Usuario } from 'src/app/models/Usuario.model';

import { HomeComponent } from './home.component';

interface IAtivo {
  ativoModel: {
    codigo: string;
    valor: number;
  };
  quantidade: number;
}

function mockAtivos() {
  let ativos = new Array<any>();
  let a1 = new Ativo();
  a1.id = '20aa7681-6cff-4979-b466-f971620d4ffe';
  a1.codigo = 'A1';
  a1.valor = 25.41;

  ativos.push(a1);

  let a2 = new Ativo();
  a2.id = '4cb89dd6-7ade-4dcc-8b78-1644ac2f5028';
  a2.codigo = 'A2';
  a2.valor = 45.44;

  ativos.push(a2);

  return ativos;
}

function mockUsuario() {
  let usuario = new Usuario();
  usuario.nome = 'Denilson Lobo';
  usuario.ContaCorrente = new ContaCorrente();
  usuario.ContaCorrente.saldo = 100;
  usuario.AtivosUsuario = new Array<any>();
  let ativoModel: IAtivo = { ativoModel: { codigo: 'A1', valor: 25.41 }, quantidade: 5 };
  usuario.AtivosUsuario.push(ativoModel);
  return usuario;
}

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  let httpClient: HttpClient;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeComponent, LoadingComponent],
      imports: [
        HttpClientTestingModule,
        ReactiveFormsModule,
        ToastrModule.forRoot(),
      ],
    }).compileComponents();

    httpClient = TestBed.inject(HttpClient);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
  it('should list assets', () => {
    component.ativos = mockAtivos();

    fixture.debugElement.nativeElement.querySelector('#tabela-ativos');
    fixture.detectChanges();
    let listItems = fixture.debugElement.queryAll(By.css('.rowB2'));

    let tdCodigo0 = listItems[0].queryAll(By.css('.codigo'));
    let tdCodigo1 = listItems[1].queryAll(By.css('.codigo'));

    let tdValor0 = listItems[0].queryAll(By.css('.valor'));
    let tdValor1 = listItems[1].queryAll(By.css('.valor'));

    expect(tdCodigo0[0].nativeElement.textContent.trim()).toEqual('A1');
    expect(tdCodigo1[0].nativeElement.textContent.trim()).toEqual('A2');
    expect(tdValor0[0].nativeElement.textContent.trim()).toEqual('R$25.41');
    expect(tdValor1[0].nativeElement.textContent.trim()).toEqual('R$45.44');
  });  

  it('should get user', () => {
    component.usuario = mockUsuario();
    fixture.detectChanges();
    
    const nomeUsuario = fixture.debugElement.query(By.css('#nome-usuario')); 
    const saldoContaCorrente = fixture.debugElement.query(By.css('#saldo-conta-corrente'));

    expect(nomeUsuario.nativeElement.textContent.trim()).toContain('Denilson Lobo');    
    expect(saldoContaCorrente.nativeElement.textContent.trim()).toContain('R$100.00');
  });

  it('should list user assets', () => {
    component.usuario = mockUsuario();
    
    fixture.debugElement.nativeElement.querySelector('#tabela-ativos-usuario');    
    fixture.detectChanges();
    let listItems = fixture.debugElement.queryAll(By.css('.rowB2'));

    let tdCodigo = listItems[0].queryAll(By.css('.codigo'));
    let tdValor = listItems[0].queryAll(By.css('.valor'));
    let tdQuantidade = listItems[0].queryAll(By.css('.quantidade'));

    expect(tdCodigo[0].nativeElement.textContent.trim()).toEqual('A1');
    expect(tdValor[0].nativeElement.textContent.trim()).toEqual('R$25.41');
    expect(tdQuantidade[0].nativeElement.textContent.trim()).toEqual('5');
  });

  it('should get selected asset on button click', fakeAsync(() => {
    component.ativos = mockAtivos();
    fixture.detectChanges();

    const btnComprarAtivo = fixture.debugElement.query(By.css('.btn-comprar-ativo'));    
    btnComprarAtivo.triggerEventHandler('click', null);
    
    expect(component.ativoSelecionadoId).toEqual('20aa7681-6cff-4979-b466-f971620d4ffe');
    expect(component.codigoAtivoSelecionado).toEqual('A1');
    expect(component.valorAtivoSelecionado.toString()).toEqual('25.41');
  }));

  it('should has valid value on button click', fakeAsync(() => {
    component.ativos = mockAtivos();
    fixture.detectChanges();

    const btnComprarAtivo = fixture.debugElement.query(By.css('.btn-comprar-ativo'));    
    btnComprarAtivo.triggerEventHandler('click', null);
    
    const btnFinalizarCompra = fixture.debugElement.query(By.css('.btn-finalizar-compra'));    
    btnFinalizarCompra.triggerEventHandler('click', null);

    (component.form.controls['quantidade'] as FormControl).setValue(1);
    expect(component.form.valid).toBeTruthy();
  }));

  it('should has invalid value on button click', fakeAsync(() => {
    component.ativos = mockAtivos();
    fixture.detectChanges();

    const btnComprarAtivo = fixture.debugElement.query(By.css('.btn-comprar-ativo'));    
    btnComprarAtivo.triggerEventHandler('click', null);
    
    const btnFinalizarCompra = fixture.debugElement.query(By.css('.btn-finalizar-compra'));    
    btnFinalizarCompra.triggerEventHandler('click', null);

    (component.form.controls['quantidade'] as FormControl).setValue(0);
    expect(component.form.invalid).toBeTruthy();

    (component.form.controls['quantidade'] as FormControl).setValue('');
    expect(component.form.invalid).toBeTruthy();

    (component.form.controls['quantidade'] as FormControl).setValue('XPTO');
    expect(component.form.invalid).toBeTruthy();
  }));
});
