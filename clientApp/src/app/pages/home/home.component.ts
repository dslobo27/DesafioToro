import { Component, OnInit } from '@angular/core';

import { Usuario } from 'src/app/models/Usuario.model';
import { AtivosService } from 'src/app/services/ativos.service';
import { UsuariosService } from 'src/app/services/usuarios.service';

import { catchError, map } from 'rxjs/operators';
import { Ativo } from 'src/app/models/Ativo.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ComprarAtivo } from 'src/app/models/ComprarAtivo.model';
import { Result } from 'src/app/models/Result.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public ativos: Array<any> = new Array<any>();
  public usuario: Usuario = new Usuario();
  public form: FormGroup = new FormGroup({});

  public usuarioLogadoId?: string = '';
  public ativoSelecionadoId: string = '';
  public codigoAtivoSelecionado: string = '';
  public valorAtivoSelecionado: string = '';

  constructor(
    private ativosService: AtivosService,
    private usuariosService: UsuariosService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      quantidade: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(/^[0-9]\d*$/),
          Validators.min(1),
        ]),
      ],
    });
  }

  ngOnInit(): void {
    this.ativosService
      .obterCincoAtivosMaisVendidos()
      .pipe(
        map((a) => {
          let atv = a;
          let ativos = new Array<Ativo>();
          atv.data.forEach((el: any) => {
            let ativo = new Ativo();
            ativo.id = el.id;
            ativo.codigo = el.codigo;
            ativo.quantidadeNegociados = el.quantidadeNegociados;
            ativo.valor = el.valor;
            ativos.push(ativo);
          });
          return ativos;
        })
      )
      .subscribe((x) => (this.ativos = x));

    this.usuarioLogadoId = sessionStorage.getItem('user')?.toString();
    this.usuariosService
      .obterPorId(this.usuarioLogadoId)
      .pipe(
        map((u) => {
          let usr = u.data;
          let usuario = new Usuario();
          usuario.id = usr.id;
          usuario.nome = usr.nome;
          usuario.AtivosUsuario = usr.ativosUsuario;
          usuario.ContaCorrente = usr.contaCorrente;
          return usuario;
        })
      )
      .subscribe((x) => (this.usuario = x));
  }

  logout(): void {
    sessionStorage.removeItem('token');
  }

  showModal(id: string, codigo: string, valor: string) {
    this.ativoSelecionadoId = id;
    this.codigoAtivoSelecionado = codigo;
    this.valorAtivoSelecionado = valor;
  }

  finalizarCompra(): void {
    let model = new ComprarAtivo();
    model.ativoId = this.ativoSelecionadoId;
    model.quantidadeSolicitada = Number(this.form.get('quantidade')?.value);
    model.usuarioId = this.usuarioLogadoId;

    this.ativosService
      .finalizarCompra(model)
      .pipe(
        map((r) => {
          let result = new Result();
          result.data = r.data;
          return result.data;
        }),
        catchError((response) => {
          let errors = response.error.errors;
          let message = '';
          errors.forEach((el: any) => {
            message += `${el}\n`;
          });
          this.toastr.error(message);
          return '';
        })
      )
      .subscribe((x) => {
        this.toastr.success(x);
      });
  }
}
