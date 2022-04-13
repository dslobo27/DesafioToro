import { Component, OnInit } from '@angular/core';
import { Ativo } from 'src/models/Ativo.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public nome: string = '';
  public saldo: string = '0,00';
  public ativos: Ativo[] = [];

  constructor() { }

  ngOnInit(): void {
    this.nome = "Denilson Lobo";
    let novoSaldo = 100.28;
    this.saldo = novoSaldo.toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        style: 'currency',
        currency: 'BRL'
    });
    this.ativos.push(new Ativo('c1e999ae-7b20-4789-8728-8b0fe732d031','PETR4', 28.44, 3));
    this.ativos.push(new Ativo('0059ae4d-cdf9-4da4-884e-4c70bdf79ae1','MGLU3', 25.91, 2));
    this.ativos.push(new Ativo('580d6a28-d68a-4796-8a92-32b8416914c0','SANB11', 40.77, 1));
  }
}
