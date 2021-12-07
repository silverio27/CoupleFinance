import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.css']
})
export class ExpenseComponent implements OnInit {

  showEdit = false;
  showFilter = false;
  constructor() { }

  ngOnInit(): void {
  }

}
