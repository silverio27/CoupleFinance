import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService, SignInRequest } from "../../services/auth.service";
import { TokenService } from "../../services/token.service";

@Component({
  templateUrl: "./signin.component.html",
  styleUrls: ["../identity/identity.component.css"],
})
export class SigninComponent implements OnInit {
  signInRequest: SignInRequest = {
    email: "",
    password: "",
  };
  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  signin() {
    this.authService.signin(this.signInRequest).subscribe((x) => {
      this.tokenService.token = x.data.token;
      this.router.navigateByUrl("/expense");
    });
  }
}
