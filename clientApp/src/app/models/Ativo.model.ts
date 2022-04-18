export class Ativo {
  public id: string;
  public codigo: string;
  public valor: number;
  public quantidadeNegociados: number;

  constructor(id: string, codigo: string, valor: number, quantidadeNegociados: number) {
      this.id = id;
      this.codigo = codigo;
      this.valor = valor;
      this.quantidadeNegociados = quantidadeNegociados;
  }
}
