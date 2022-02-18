import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { IdentityRoutingModule } from "./identity-routing.module";
import { UsersComponent } from "./pages/users/users.component";
import { IdentityComponent } from "./pages/identity/identity.component";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { SharedComponentsModule } from "../shared-components/shared-components.module";
import { SigninComponent } from './pages/signin/signin.component';
import { SignupComponent } from './pages/signup/signup.component';
import { VerifyAccountComponent } from './pages/verify-account/verify-account.component';
import { CheckYourEmailComponent } from './pages/check-your-email/check-your-email.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@NgModule({
  declarations: [UsersComponent, IdentityComponent, SigninComponent, SignupComponent, VerifyAccountComponent, CheckYourEmailComponent],
  imports: [
    CommonModule,
    IdentityRoutingModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    FormsModule,
    MatSnackBarModule,
    SharedComponentsModule,
    MatProgressSpinnerModule
  ],
})
export class IdentityModule {}
