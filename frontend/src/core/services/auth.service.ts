import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';
import { UserLoginModel } from './models/user-login-model';

@Injectable({
  providedIn: 'root',
})
export class Authervice {
  public routePrefix = '/api/auth';

  constructor(private httpService: HttpService) {}

  public Autn(credentials: UserLoginModel): Observable<HttpResponse<string>> {
    return this.httpService.postFullRequest(
      this.routePrefix,
      credentials
    );
  }
}
