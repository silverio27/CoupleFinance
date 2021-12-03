import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { MatSidenavModule } from "@angular/material/sidenav";
import { ToolbarComponent } from "./toolbar/toolbar.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import {OverlayModule} from '@angular/cdk/overlay';

import { SideMenuComponent } from "./side-menu/side-menu.component";
import { UserAvatarComponent } from "./user-avatar/user-avatar.component";
import { CategoryPresentsComponent } from "./category-presents/category-presents.component";
import { InvolvedInTheExpenseComponent } from "./involved-in-the-expense/involved-in-the-expense.component";
import { MatTooltipModule } from "@angular/material/tooltip";
import { CurrencyMaskModule } from "ng2-currency-mask";
import { FormsModule } from "@angular/forms";
import {MatAutocompleteModule} from '@angular/material/autocomplete';

@NgModule({
  declarations: [
    SideMenuComponent,
    ToolbarComponent,
    UserAvatarComponent,
    CategoryPresentsComponent,
    InvolvedInTheExpenseComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    OverlayModule,
    MatTooltipModule,
    CurrencyMaskModule,
    MatAutocompleteModule
  ],
  exports: [
    SideMenuComponent,
    ToolbarComponent,
    CategoryPresentsComponent,
    InvolvedInTheExpenseComponent,
    UserAvatarComponent
  ],
})
export class SharedComponentsModule {}
