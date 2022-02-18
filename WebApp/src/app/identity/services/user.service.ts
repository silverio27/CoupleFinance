import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

const url = `${environment.urlApi}/users/`;
export interface SignUpRequest {
  name: string;
  email: string;
  password: string;
  confirmPassword: string;
}

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private http: HttpClient) {}
  create(request: SignUpRequest) {
    return this.http.post(url, request);
  }
}
