import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CheckYourEmailComponent } from "./pages/check-your-email/check-your-email.component";
import { IdentityComponent } from "./pages/identity/identity.component";
import { SigninComponent } from "./pages/signin/signin.component";
import { SignupComponent } from "./pages/signup/signup.component";
import { UsersComponent } from "./pages/users/users.component";
import { VerifyAccountComponent } from "./pages/verify-account/verify-account.component";

const routes: Routes = [
  { path: "", component: IdentityComponent, children:[

    { path: 'signin', component: SigninComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'check-your-email', component: CheckYourEmailComponent },
    { path: 'verify-account/:userId/:codeActivation', component: VerifyAccountComponent },
    { path: '', pathMatch: 'full', redirectTo: 'signin' },
  ] },
  { path: "users", component: UsersComponent },
  { path: "", pathMatch: "full", redirectTo: "" },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IdentityRoutingModule {}
