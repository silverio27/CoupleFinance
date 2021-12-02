import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
export interface UserData {
  category: string;
  who: string;
  value: number;
  realValue: number;
  bank:string;
}

/** Constants used to fill up our data base. */
const CATEGORY: string[] = [
  'alimentação',
  'educação',
  'moradia',
  'dívida',
  'lazer',
  'carro',
  'gasolina',
  'saúde',
];
const WHO: string[] = [
  'Lucas',
  'Samara'
];
@Component({
  selector: 'cf-expense-table',
  templateUrl: './expense-table.component.html',
  styleUrls: ['./expense-table.component.css']
})
export class ExpenseTableComponent implements AfterViewInit{
  displayedColumns: string[] = ['category', 'who','bank', 'value', 'realValue', 'actions'];
  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {
    // Create 100 users
    const users = Array.from({length: 100}, (_, k) => createNewUser(k + 1));

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(users);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }


}

/** Builds and returns a new User. */
function createNewUser(id: number): UserData {
  const name =
    CATEGORY[Math.round(Math.random() * (CATEGORY.length - 1))] +
    ' ' +
    CATEGORY[Math.round(Math.random() * (CATEGORY.length - 1))].charAt(0) +
    '.';
    let ivalue = Math.round(Math.random() * 100);

  return {
    category: name,
    who: WHO[Math.round(Math.random() * (WHO.length - 1))],
    bank: 'Nubank',
    value: ivalue,
    realValue: ivalue/ 2,
  };

}
