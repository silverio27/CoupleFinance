import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ExpenseRoutingModule } from './expense-routing.module';
import { ExpenseComponent } from './pages/expense.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';

import { ExpenseTableComponent } from './components/expense-table/expense-table.component';
import { ExpenseResumeComponent } from './components/expense-resume/expense-resume.component';



@NgModule({
  declarations: [
    ExpenseComponent,
    ExpenseTableComponent,
    ExpenseResumeComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ExpenseRoutingModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    
  ]
})
export class ExpenseModule { }
