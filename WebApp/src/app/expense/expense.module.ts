import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ExpenseRoutingModule } from './expense-routing.module';
import { ExpenseComponent } from './pages/expense.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';

import { ExpenseTableComponent } from './components/expense-table/expense-table.component';
import { ExpenseResumeComponent } from './components/expense-resume/expense-resume.component';
import { SharedComponentsModule } from '../shared-components/shared-components.module';
import { ExpenseEditComponent } from './components/expense-edit/expense-edit.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ExpenseFilterComponent } from './components/expense-filter/expense-filter.component';

import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';



@NgModule({
  declarations: [
    ExpenseComponent,
    ExpenseTableComponent,
    ExpenseResumeComponent,
    ExpenseEditComponent,
    ExpenseFilterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ExpenseRoutingModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    CurrencyMaskModule,
    SharedComponentsModule,
    MatSidenavModule,
    MatDatepickerModule,
    MatSlideToggleModule
  ]
})
export class ExpenseModule { }
