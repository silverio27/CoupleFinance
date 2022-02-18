import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { SignUpRequest, UserService } from "../../services/user.service";

@Component({
  templateUrl: "./signup.component.html",
  styleUrls: ["../identity/identity.component.css"],
})
export class SignupComponent implements OnInit {
  signUpRequest: SignUpRequest = {
    confirmPassword: "",
    email: "",
    name: "",
    password: "",
  };

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {}

  signup() {
    this.userService.create(this.signUpRequest).subscribe((x) => {
      this.router.navigateByUrl('../check-your-email')
    });
  }
}
