import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthService implements CanActivate {
  constructor(private router: Router) {}

  canActivate() {
    const token = sessionStorage.getItem('token');
    if (!token) {
      this.router.navigate(['/']);
      return false;
    }
    return true;
  }
}
