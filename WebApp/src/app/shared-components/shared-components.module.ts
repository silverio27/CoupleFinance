import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";


import { MatSidenavModule } from "@angular/material/sidenav";
import { ToolbarComponent } from "./toolbar/toolbar.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import {MatListModule} from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

import { SideMenuComponent } from "./side-menu/side-menu.component";
import { UserAvatarComponent } from './user-avatar/user-avatar.component';

@NgModule({
  declarations: [SideMenuComponent, ToolbarComponent, UserAvatarComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule

  ],
  exports: [SideMenuComponent, ToolbarComponent],
})
export class SharedComponentsModule {}
