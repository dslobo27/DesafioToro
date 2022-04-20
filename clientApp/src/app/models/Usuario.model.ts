import { ContaCorrente } from "./ContaCorrente.model";

export class Usuario {
  public id: string = '';
  public nome: string = '';
  
  public ContaCorrente: ContaCorrente = new ContaCorrente();
  public AtivosUsuario: Array<any> = new Array<any>();
}
