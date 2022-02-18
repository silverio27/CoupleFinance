import { Component, OnInit } from "@angular/core";
import { TokenService, UserDecode } from "./identity/services/token.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  user ={}as UserDecode ;
  constructor(public tokenService: TokenService) {}
  ngOnInit(): void {
    this.tokenService.user.subscribe((x) => {
      this.user = x
    });
  }
}
