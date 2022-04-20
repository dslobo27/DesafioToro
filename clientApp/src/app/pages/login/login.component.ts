import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { catchError, map } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public form: FormGroup = new FormGroup({});

  constructor(
    private loginService: LoginService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      cpf: [
        '',
        Validators.compose([Validators.minLength(11), Validators.required]),
      ],
      senha: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  submit(): void {
    this.loginService
      .autenticar(this.form.value)
      .pipe(
        map((result) => {
          return result;
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
      .subscribe((result: any) => {
        sessionStorage.setItem('token', result.data);

        const helper = new JwtHelperService();
        const decodedToken = helper.decodeToken(result.data);
        sessionStorage.setItem('user', decodedToken.primarysid);

        this.router.navigate(['/home']);
      });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }
}
