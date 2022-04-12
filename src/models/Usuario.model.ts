import { Ativo } from "./Ativo.model";
import { ContaCorrente } from "./ContaCorrente.model";

export class Usuario {
  public id: string = '';
  public contaCorrenteId: string = '';
  public nome: string = '';
  public cpf: string = '';

  public ContaCorrente: ContaCorrente = new ContaCorrente();
  public Ativos: Ativo[] = [];
}
