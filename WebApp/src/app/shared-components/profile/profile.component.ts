import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { AuthService } from "src/app/identity/services/auth.service";
import {
  TokenService,
  UserDecode,
} from "src/app/identity/services/token.service";

@Component({
  selector: "cf-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProfileComponent implements OnInit {
  user = {} as UserDecode;
  constructor(
    private tokenService: TokenService,
    private authService: AuthService
  ) {
    this.tokenService.user.subscribe((x) => {
      this.user = x;
    });
  }

  ngOnInit(): void {}

  logout() {
    this.authService.logout();
  }
}
