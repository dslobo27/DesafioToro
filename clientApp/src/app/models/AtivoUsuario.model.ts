import { Ativo } from "./Ativo.model";
import { Usuario } from "./Usuario.model";

export class AtivoUsuario {
  public ativo: Ativo = new Ativo('', '', 0, 0);
  public usuario: Usuario = new Usuario();
}
