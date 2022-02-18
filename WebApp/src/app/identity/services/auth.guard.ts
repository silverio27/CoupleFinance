import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private tokenService: TokenService, private router: Router) {}
  canActivate() {
    const activate = this.tokenService.token != null;
    if (!activate) this.router.navigateByUrl('/identity');
    return activate;
  }
  
}
