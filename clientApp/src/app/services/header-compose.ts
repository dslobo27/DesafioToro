import { HttpHeaders } from '@angular/common/http';

export class HeaderCompose {
  public static compose() {
    const token = sessionStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `bearer ${token}`);
    return headers;
  }
}
