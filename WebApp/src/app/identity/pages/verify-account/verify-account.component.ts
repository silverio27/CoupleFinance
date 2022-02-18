import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Route, Router } from "@angular/router";
import { ActiveAccountRequest, AuthService } from "../../services/auth.service";

@Component({
  templateUrl: "./verify-account.component.html",
  styleUrls: ["../identity/identity.component.css"],
})
export class VerifyAccountComponent implements OnInit {
  request = {} as ActiveAccountRequest;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {
    this.route.params.subscribe((x: any) => {
      this.request = x;
    });
  }

  ngOnInit(): void {
    this.authService.activeAccount(this.request).subscribe((x)=>{
this.router.navigateByUrl("./expenses")
    })
  }
}
