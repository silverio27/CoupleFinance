import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { IResponse } from "src/app/response";
import { environment } from "src/environments/environment";
import { TokenService } from "./token.service";
export interface SignInRequest {
  email: string;
  password: string;
}

export interface ActiveAccountRequest {
  userId: string;
  codeActivation: string;
}
export interface LogoutRequest {}

const url = `${environment.urlApi}/auth/`;
@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private http: HttpClient,  private tokenService: TokenService, private router: Router) {}

  signin(request: SignInRequest): Observable<IResponse> {
    return this.http.post<IResponse>(`${url}signin`, request);
  }
  activeAccount(request: ActiveAccountRequest): Observable<IResponse> {
    return this.http.post<IResponse>(`${url}active-account`, request);
  }

  logout() {
    this.tokenService.removeToken();
    this.tokenService.user
    this.router.navigateByUrl('/identity')
  
  }
}
