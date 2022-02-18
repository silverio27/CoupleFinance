import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { switchMap } from "rxjs/operators";
import { AuthService, SignInRequest } from "../../services/auth.service";
import { TokenService } from "../../services/token.service";
import { SignUpRequest, UserService } from "../../services/user.service";

@Component({
  templateUrl: "./identity.component.html",
  styleUrls: ["./identity.component.css"],
})
export class IdentityComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
