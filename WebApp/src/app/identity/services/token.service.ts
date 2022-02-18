import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { TOKEN_STORAGE } from "src/environments/environment";
import jwt_decode from 'jwt-decode';
export interface UserDecode {
  username: string;
  id: string;
  role: string;
  email:string;
}

@Injectable({
  providedIn: "root",
})
export class TokenService {
  private _user = new BehaviorSubject<UserDecode>(this.decodePayloadJWT());
  user = this._user.asObservable();
  constructor() {}

  get token(): string | null {
    return localStorage.getItem(TOKEN_STORAGE);
  }

  set token(token: string | null) {
    localStorage.setItem(TOKEN_STORAGE, token as string);
    this._user.next(this.decodePayloadJWT());
  }

  removeToken() {
    this._user.next(null as unknown as UserDecode);
    localStorage.removeItem(TOKEN_STORAGE);
  }

  private decodePayloadJWT(): any {
    try {
      return jwt_decode(this.token as string);
    } catch (error) {
      return null;
    }
  }
}
