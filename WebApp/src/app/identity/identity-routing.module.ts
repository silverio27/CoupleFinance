import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SigninComponent } from "./pages/signin/signin.component";
import { UsersComponent } from "./pages/users/users.component";

const routes: Routes = [
  { path: "users", component: UsersComponent },
  { path: "signin", component: SigninComponent },
  { path: '', pathMatch: 'full', redirectTo: 'users' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IdentityRoutingModule {}
