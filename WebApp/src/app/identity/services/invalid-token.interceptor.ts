import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { AuthService } from "./auth.service";
import { MatSnackBar } from "@angular/material/snack-bar";
import { catchError } from "rxjs/operators";

@Injectable()
export class InvalidTokenInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthService,
    private snackBar: MatSnackBar
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((errorResponse) => {
        if (errorResponse.status == 401) {
          this.authService.logout();
        }else{
          this.snackBar.open('Erro','Fechar')
        }
        return throwError(errorResponse);
      })
    );
  }
}
