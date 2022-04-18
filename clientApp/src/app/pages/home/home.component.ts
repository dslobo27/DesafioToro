import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AtivosService } from 'src/app/services/ativos.service';
import { Ativo } from '../../models/Ativo.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public nome: string = '';
  public saldo: string = '0,00';
  public ativos: Observable<Array<Ativo>> = new Observable<Array<Ativo>>();

  constructor(private ativosService: AtivosService) { }

  ngOnInit(): void {
    this.ativos = this.ativosService.obterCincoAtivosMaisVendidos();

    this.nome = "Denilson Lobo";
    let novoSaldo = 100.28;
    this.saldo = novoSaldo.toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        style: 'currency',
        currency: 'BRL'
    });
  }
}
