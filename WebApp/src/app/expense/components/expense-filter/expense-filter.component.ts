import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'cf-expense-filter',
  templateUrl: './expense-filter.component.html',
  styleUrls: ['./expense-filter.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpenseFilterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
